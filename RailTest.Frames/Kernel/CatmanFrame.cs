using RailTest.Algebra;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace RailTest.Frames
{
    partial class Kernel
    {
        public static Tuple<FrameHeader, ChannelCollection> LoadCatmanFrame(string path, FileReader reader, FileReadMode readMode)
        {
            try
            {
                reader.Position = 2;
                CatmanFrameHeader frameHeader = new CatmanFrameHeader();
                ChannelCollection channels = new ChannelCollection();

                int dataOffset =  reader.ReadInt32();
                frameHeader.Comment = ReadASCIIString(reader, reader.ReadInt16());
                for (int i = 0; i != 32; ++i)
                {
                    frameHeader.Reserve[i] = ReadASCIIString(reader, reader.ReadInt16());
                }

                int numberOfChannels = reader.ReadInt16();
                int[] offsetChannelLength = new int[numberOfChannels];

                frameHeader.MaximumChannelLength = reader.ReadInt32();
                for (int i = 0; i != numberOfChannels; ++i)
                {
                    offsetChannelLength[i] = reader.ReadInt32();
                }

                //  Проверка компресии данных.
                if (reader.ReadInt32() != 0)
                {
                    throw new NotSupportedException("Произошла попытка чтения файла с компресией данных.");
                }

                if (numberOfChannels > 0)
                {
                    for (int i = 0; i != numberOfChannels; ++i)
                    {
                        int channelLength = 0;
                        reader.Position = offsetChannelLength[i] - 2;
                        CatmanChannelHeader channelHeader = new CatmanChannelHeader();


                        channelHeader.LocationInDatabase = reader.ReadInt16();
                        channelLength = reader.ReadInt32();
                        channelHeader.Name = ReadASCIIString(reader, reader.ReadInt16());
                        channelHeader.Unit = ReadASCIIString(reader, reader.ReadInt16());
                        channelHeader.Comment = ReadASCIIString(reader, reader.ReadInt16());
                        channelHeader.DataFormat = (CatmanDataFormat)reader.ReadInt16();
                        channelHeader.DataWidth = reader.ReadInt16();
                        channelHeader.Time = DateTime.FromOADate(reader.ReadFloat64());
                        channelHeader.SizeOfExtendedHeader = reader.ReadInt32();

                        if (channelHeader.SizeOfExtendedHeader < 148)
                        {
                            throw new InvalidDataException("Произошла попытка загрузить файл некорректного формата.");
                        }

                        channelHeader.StartTime = DateTime.FromOADate(reader.ReadFloat64());
                        channelHeader.SamplingTimeStep = reader.ReadFloat64();
                        channelHeader.Sampling = 1000 / channelHeader.SamplingTimeStep;
                        channelHeader.CodeOfSensorType = (CatmanCodeOfSensorType)reader.ReadInt16();
                        channelHeader.CodeOfSupplyVoltage = (CatmanCodeOfSupplyVoltage)reader.ReadInt16();
                        channelHeader.CodeOfFilterCharacteristics = (CatmanCodeOfFilterCharacteristics)reader.ReadInt16();
                        channelHeader.CodeOfFilterFrequency = (CatmanCodeOfFilterFrequency)reader.ReadInt16();
                        channelHeader.TareValue = reader.ReadFloat32();
                        channelHeader.ZeroValue = reader.ReadFloat32();
                        channelHeader.CodeOfMeasuringRange = (CatmanCodeOfMeasuringRange)reader.ReadFloat32();
                        channelHeader.InputCharacteristics = new double[4];
                        channelHeader.InputCharacteristics[0] = reader.ReadFloat32();
                        channelHeader.InputCharacteristics[1] = reader.ReadFloat32();
                        channelHeader.InputCharacteristics[2] = reader.ReadFloat32();
                        channelHeader.InputCharacteristics[3] = reader.ReadFloat32();
                        channelHeader.AmplifierSerialNumber = ReadASCIIString(reader, 32);
                        channelHeader.PhysicalUnit = ReadASCIIString(reader, 8);
                        channelHeader.NativeUnit = ReadASCIIString(reader, 8);
                        channelHeader.HardwareSlotNumber = reader.ReadInt16();
                        channelHeader.HardwareSubSlotNumber = reader.ReadInt16();
                        channelHeader.CodeOfAmplifierType = reader.ReadInt16();
                        channelHeader.CodeOfAPConnectorType = reader.ReadInt16();
                        channelHeader.GageFactor = reader.ReadFloat32();
                        channelHeader.BridgeFactor = reader.ReadFloat32();
                        channelHeader.CodeOfMeasurementSignal = reader.ReadInt16();
                        channelHeader.CodeOfAmplifierInput = reader.ReadInt16();
                        channelHeader.CodeOfHighpassFilter = reader.ReadInt16();
                        channelHeader.OnlineImportInfo = reader.ReadUInt8();
                        channelHeader.CodeOfScaleType = reader.ReadUInt8();
                        channelHeader.SoftwareZeroValue = reader.ReadFloat32();
                        channelHeader.WriteProtected = reader.ReadUInt8();
                        channelHeader.Alignment = new byte[3];
                        channelHeader.Alignment[0] = reader.ReadUInt8();
                        channelHeader.Alignment[1] = reader.ReadUInt8();
                        channelHeader.Alignment[2] = reader.ReadUInt8();
                        channelHeader.NominalRange = reader.ReadFloat32();
                        channelHeader.CableLengthCompensation = reader.ReadFloat32();
                        channelHeader.ExportFormat = reader.ReadUInt8();
                        channelHeader.ChannelType = reader.ReadInt8();
                        channelHeader.EDaqConnectorOnLayer = reader.ReadUInt8();
                        channelHeader.EDaqLayer = reader.ReadUInt8();
                        channelHeader.ContentType = reader.ReadUInt8();
                        channelHeader.Reserved = new byte[3];
                        channelHeader.Reserved[0] = reader.ReadUInt8();
                        channelHeader.Reserved[1] = reader.ReadUInt8();
                        channelHeader.Reserved[2] = reader.ReadUInt8();

                        channelHeader.LinearisationMode = reader.ReadUInt8();
                        channelHeader.UserScaleType = reader.ReadUInt8();
                        channelHeader.NumberOfPointsScaleTable = reader.ReadUInt8();
                        if (channelHeader.NumberOfPointsScaleTable != 0)
                        {
                            channelHeader.PointsScaleTable = new double[channelHeader.NumberOfPointsScaleTable];
                            for (int j = 0; j != channelHeader.NumberOfPointsScaleTable; ++j)
                            {
                                channelHeader.PointsScaleTable[j] = reader.ReadFloat64();
                            }
                        }

                        channelHeader.ThermoType = reader.ReadInt16();
                        channelHeader.Formula = ReadASCIIString(reader, reader.ReadInt16());
                        channelHeader.SensorInfo = new CatmanSensorInfo();
                        int sensorInfoSize = reader.ReadInt32();
                        if (sensorInfoSize != 68)
                        {
                            throw new InvalidDataException("Произошла попытка загрузить файл некорректного формата.");
                        }
                        channelHeader.SensorInfo.InUse = reader.ReadInt16() != 0;
                        channelHeader.SensorInfo.Description = ReadASCIIString(reader,50);
                        channelHeader.SensorInfo.Tid = ReadASCIIString(reader, 16);

                        RealVector vector = new RealVector(channelLength);
                        channels.Add(new Channel(channelHeader, vector));
                    }

                    reader.Position = dataOffset;
                    foreach (Channel channel in channels)
                    {
                        CatmanChannelHeader channelHeader = (CatmanChannelHeader)channel.Header;
                        switch (channelHeader.ExportFormat)
                        {
                            case 0:
                                for (int i = 0; i != channel.Length; ++i)
                                {
                                    channel[i] = reader.ReadFloat64();
                                }
                                break;
                            case 1:
                                for (int i = 0; i != channel.Length; ++i)
                                {
                                    channel[i] = reader.ReadFloat32();
                                }
                                break;
                            case 2:
                                channelHeader.MinValueFactor = reader.ReadFloat64();
                                channelHeader.MinValueFactor = reader.ReadFloat64();
                                for (int i = 0; i != channel.Length; ++i)
                                {
                                    channel[i] = reader.ReadInt16() / 32767 * (channelHeader.MinValueFactor - channelHeader.MinValueFactor) + channelHeader.MinValueFactor;
                                }
                                break;
                            default:
                                throw new InvalidDataException("Произошла попытка загрузить файл некорректного формата.");
                        }
                    }

                    //  Проверка Id Post data ares
                    if (reader.ReadInt16() != 4001)
                    {
                        throw new InvalidDataException("Произошла попытка загрузить файл некорректного формата.");
                    }

                    foreach (Channel channel in channels)
                    {
                        ((CatmanChannelHeader)channel.Header).FormatString = ReadASCIIString(reader, reader.ReadInt16());
                    }
                }
                return new Tuple<FrameHeader, ChannelCollection>(frameHeader, channels);
            }
            catch (Exception ex)
            {
                throw new InvalidDataException("Произошла ошибка при чтении файла.", ex);
            }
        }

        public static void SaveCatmanFrame(Frame frame, FileWriter writer)
        {
            Action<string> writeString = (string text) =>
            {
                writer.WriteInt16((short)text.Length);
                if (text.Length > 0)
                {
                    WriteASCIIString(writer, text, text.Length, false);
                }
            };

            try
            {
                writer.Position = 0;
                CatmanFrameHeader frameHeader = (CatmanFrameHeader)frame.Header.Convert(StorageFormat.Catman);

                int numberOfChannels = frame.Channels.Count;
                int[] offsetChannelLength = new int[numberOfChannels];
                List<CatmanChannelHeader> channelHeaders = new List<CatmanChannelHeader>();

                int dataOffset = 2 + 4 + 2 + frameHeader.Comment.Length;
                for (int i = 0; i != 32; ++i)
                {
                    dataOffset += 2 + frameHeader.Reserve[i].Length;
                }
                dataOffset += 2 + 4 + numberOfChannels * 4 + 4;

                for (int i = 0; i != numberOfChannels; ++i)
                {
                    Channel channel = frame.Channels[i];
                    CatmanChannelHeader channelHeader = (CatmanChannelHeader)channel.Header.Convert(StorageFormat.Catman);
                    channelHeaders.Add(channelHeader);
                    offsetChannelLength[i] = dataOffset + 2;

                    dataOffset += 2 + 4 + (2 + channelHeader.Name.Length)
                         + (2 + channelHeader.Unit.Length) + (2 + channelHeader.Comment.Length);

                    dataOffset += 2 + 2 + 8 + 4 + 8 + 8 + 2 + 2 + 2 + 2 + 4 + 4 + 4 + 4*4 + 32
                        +8 +8 + 2 * 4 + 2*4 + 2*3 + 2 + 4 + 4 + 4*2 + 2 + 9 + channelHeader.NumberOfPointsScaleTable*8
                        +2 + (2 + channelHeader.Formula.Length) + 4 + 2 + 50 + 16;
                }
                
                writer.WriteUInt16(0x1394); //  2
                writer.WriteInt32(dataOffset);  //  4
                
                writeString(frameHeader.Comment);
                for (int i = 0; i != 32; ++i)
                {
                    writeString(frameHeader.Reserve[i]);
                }

                writer.WriteInt16((short)numberOfChannels);    //  2
                writer.WriteInt32(frameHeader.MaximumChannelLength);    //  4
                for (int i = 0; i != numberOfChannels; ++i)
                {
                    writer.WriteInt32(offsetChannelLength[i]);  //  4
                }

                writer.WriteInt32(0);   //  4

                if (numberOfChannels > 0)
                {
                    for (int i = 0; i != numberOfChannels; ++i)
                    {
                        if (offsetChannelLength[i] != writer.Position + 2)
                        {
                            throw new Exception();
                        }

                        Channel channel = frame.Channels[i];
                        CatmanChannelHeader channelHeader = channelHeaders[i];

                        int channelLength = channel.Length;
                        writer.WriteInt16((short)channelHeader.LocationInDatabase);    //  2
                        writer.WriteInt32(channelLength);   //  4
                        writeString(channelHeader.Name);
                        writeString(channelHeader.Unit);
                        writeString(channelHeader.Comment);

                        writer.WriteInt16((short)channelHeader.DataFormat);    //  2
                        writer.WriteInt16((short)channelHeader.DataWidth);    //  2
                        writer.WriteFloat64(channelHeader.Time.ToOADate());    //  8

                        writer.WriteInt32(148);    //  4
                        writer.WriteFloat64(channelHeader.StartTime.ToOADate());    //  8
                        writer.WriteFloat64(channelHeader.SamplingTimeStep);    //  8

                        writer.WriteInt16((short)channelHeader.CodeOfSensorType);  //  2
                        writer.WriteInt16((short)channelHeader.CodeOfSupplyVoltage);  //  2
                        writer.WriteInt16((short)channelHeader.CodeOfFilterCharacteristics);  //  2
                        writer.WriteInt16((short)channelHeader.CodeOfFilterFrequency);  //  2
                        writer.WriteFloat32((float)channelHeader.TareValue);    //  4
                        writer.WriteFloat32((float)channelHeader.ZeroValue);    //  4
                        writer.WriteFloat32((float)channelHeader.CodeOfMeasuringRange);    //  4

                        writer.WriteFloat32((float)channelHeader.InputCharacteristics[0]);    //  4
                        writer.WriteFloat32((float)channelHeader.InputCharacteristics[1]);    //  4
                        writer.WriteFloat32((float)channelHeader.InputCharacteristics[2]);    //  4
                        writer.WriteFloat32((float)channelHeader.InputCharacteristics[3]);    //  4

                        WriteASCIIString(writer, channelHeader.AmplifierSerialNumber, 32, false);   //  32
                        WriteASCIIString(writer, channelHeader.PhysicalUnit, 8, false); //  8
                        WriteASCIIString(writer, channelHeader.NativeUnit, 8, false);   //  8

                        writer.WriteInt16((short)channelHeader.HardwareSlotNumber);  //  2
                        writer.WriteInt16((short)channelHeader.HardwareSubSlotNumber);  //  2
                        writer.WriteInt16((short)channelHeader.CodeOfAmplifierType);  //  2
                        writer.WriteInt16((short)channelHeader.CodeOfAPConnectorType);  //  2

                        writer.WriteFloat32((float)channelHeader.GageFactor);    //  4
                        writer.WriteFloat32((float)channelHeader.BridgeFactor);    //  4

                        writer.WriteInt16((short)channelHeader.CodeOfMeasurementSignal);  //  2
                        writer.WriteInt16((short)channelHeader.CodeOfAmplifierInput);  //  2
                        writer.WriteInt16((short)channelHeader.CodeOfHighpassFilter);  //  2

                        writer.WriteUInt8((byte)channelHeader.OnlineImportInfo);  //  1
                        writer.WriteUInt8((byte)channelHeader.CodeOfScaleType);   //  1

                        writer.WriteFloat32((float)channelHeader.SoftwareZeroValue);   //  4

                        writer.WriteUInt8((byte)channelHeader.WriteProtected);   //  1
                        writer.WriteUInt8(0);   //  1
                        writer.WriteUInt8(0);   //  1
                        writer.WriteUInt8(0);   //  1

                        writer.WriteFloat32((float)channelHeader.NominalRange);    //  4
                        writer.WriteFloat32((float)channelHeader.CableLengthCompensation);    //  4

                        writer.WriteUInt8((byte)channelHeader.ExportFormat);  //  1
                        writer.WriteInt8((sbyte)channelHeader.ChannelType);    //  1

                        writer.WriteUInt8((byte)channelHeader.EDaqConnectorOnLayer);  //  1
                        writer.WriteUInt8((byte)channelHeader.EDaqLayer);  //  1
                        writer.WriteUInt8((byte)channelHeader.ContentType);  //  1
                        writer.WriteUInt8(0);  //  1
                        writer.WriteUInt8(0);  //  1
                        writer.WriteUInt8(0);  //  1
                        writer.WriteUInt8((byte)channelHeader.LinearisationMode);  //  1
                        writer.WriteUInt8((byte)channelHeader.UserScaleType);  //  1
                        writer.WriteUInt8((byte)channelHeader.NumberOfPointsScaleTable);  //  1
                        if (channelHeader.NumberOfPointsScaleTable != 0)
                        {
                            for (int j = 0; j != channelHeader.NumberOfPointsScaleTable; ++j)
                            {
                                writer.WriteFloat64(channelHeader.PointsScaleTable[j]); //  8
                            }
                        }

                        writer.WriteInt16((short)channelHeader.ThermoType);    //  2
                        writeString(channelHeader.Formula);

                        writer.WriteInt32(68);  //  4
                        writer.WriteInt16((short)(channelHeader.SensorInfo.InUse? 1: 0));    //  2

                        WriteASCIIString(writer, channelHeader.SensorInfo.Description, 50, false);    //  50
                        WriteASCIIString(writer, channelHeader.SensorInfo.Tid, 16, false);    //  16
                    }

                    //    dataOffset = stream.Position
                    for (int i = 0; i != numberOfChannels; ++i)
                    {
                        Channel channel = frame.Channels[i];
                        CatmanChannelHeader channelHeader = channelHeaders[i];
                        switch (channelHeader.ExportFormat)
                        {
                            case 0:
                                for (int j = 0; j != channel.Length; ++j)
                                {
                                    writer.WriteFloat64(channel[j]);
                                }
                                break;
                            case 1:
                                for (int j = 0; j != channel.Length; ++j)
                                {
                                    writer.WriteFloat32((float)channel[j]);
                                }
                                break;
                            case 2:
                                writer.WriteFloat64(channelHeader.MinValueFactor);
                                writer.WriteFloat64(channelHeader.MinValueFactor);
                                for (int j = 0; j != channel.Length; ++j)
                                {
                                    writer.WriteInt16((short)(32767 * (channel[j] - channelHeader.MinValueFactor) / (channelHeader.MinValueFactor - channelHeader.MinValueFactor)));
                                }
                                break;
                            default:
                                throw new InvalidDataException("Произошла попытка сохранить файл некорректного формата.");
                        }
                    }
                    writer.WriteInt16((short)4001);


                    for (int i = 0; i != numberOfChannels; ++i)
                    {
                        CatmanChannelHeader channelHeader = channelHeaders[i];
                        writeString(channelHeader.FormatString);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Произошла ошибка при записи файла.", ex);
            }
        }
    }
}