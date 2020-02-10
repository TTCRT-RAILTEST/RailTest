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

        [SuppressUnmanagedCodeSecurity]
        unsafe public static string ReadASCIIString(FileReader reader, int length)
        {
            StringBuilder text = new StringBuilder();
            fixed (byte* bytes = reader.ReadBytes(length))
            {
                int index = 0;
                while (index < length && bytes[index] != 0)
                {
                    switch (bytes[index])
                    {
                        case 0x20: text.Append(' '); break;
                        case 0x21: text.Append('!'); break;
                        case 0x22: text.Append('\"'); break;
                        case 0x23: text.Append('#'); break;
                        case 0x24: text.Append('$'); break;
                        case 0x25: text.Append('%'); break;
                        case 0x26: text.Append('&'); break;
                        case 0x27: text.Append('\''); break;
                        case 0x28: text.Append('('); break;
                        case 0x29: text.Append(')'); break;
                        case 0x2A: text.Append('*'); break;
                        case 0x2B: text.Append('+'); break;
                        case 0x2C: text.Append(','); break;
                        case 0x2D: text.Append('-'); break;
                        case 0x2E: text.Append('.'); break;
                        case 0x2F: text.Append('/'); break;

                        case 0x30: text.Append('0'); break;
                        case 0x31: text.Append('1'); break;
                        case 0x32: text.Append('2'); break;
                        case 0x33: text.Append('3'); break;
                        case 0x34: text.Append('4'); break;
                        case 0x35: text.Append('5'); break;
                        case 0x36: text.Append('6'); break;
                        case 0x37: text.Append('7'); break;
                        case 0x38: text.Append('8'); break;
                        case 0x39: text.Append('9'); break;
                        case 0x3A: text.Append(':'); break;
                        case 0x3B: text.Append(';'); break;
                        case 0x3C: text.Append('<'); break;
                        case 0x3D: text.Append('='); break;
                        case 0x3E: text.Append('>'); break;
                        case 0x3F: text.Append('?'); break;

                        case 0x40: text.Append('@'); break;
                        case 0x41: text.Append('A'); break;
                        case 0x42: text.Append('B'); break;
                        case 0x43: text.Append('C'); break;
                        case 0x44: text.Append('D'); break;
                        case 0x45: text.Append('E'); break;
                        case 0x46: text.Append('F'); break;
                        case 0x47: text.Append('G'); break;
                        case 0x48: text.Append('H'); break;
                        case 0x49: text.Append('I'); break;
                        case 0x4A: text.Append('J'); break;
                        case 0x4B: text.Append('K'); break;
                        case 0x4C: text.Append('L'); break;
                        case 0x4D: text.Append('M'); break;
                        case 0x4E: text.Append('N'); break;
                        case 0x4F: text.Append('O'); break;

                        case 0x50: text.Append('P'); break;
                        case 0x51: text.Append('Q'); break;
                        case 0x52: text.Append('R'); break;
                        case 0x53: text.Append('S'); break;
                        case 0x54: text.Append('T'); break;
                        case 0x55: text.Append('U'); break;
                        case 0x56: text.Append('V'); break;
                        case 0x57: text.Append('W'); break;
                        case 0x58: text.Append('X'); break;
                        case 0x59: text.Append('Y'); break;
                        case 0x5A: text.Append('Z'); break;
                        case 0x5B: text.Append('['); break;
                        case 0x5C: text.Append('\\'); break;
                        case 0x5D: text.Append(']'); break;
                        case 0x5E: text.Append('^'); break;
                        case 0x5F: text.Append('_'); break;

                        case 0x60: text.Append('`'); break;
                        case 0x61: text.Append('a'); break;
                        case 0x62: text.Append('b'); break;
                        case 0x63: text.Append('c'); break;
                        case 0x64: text.Append('d'); break;
                        case 0x65: text.Append('e'); break;
                        case 0x66: text.Append('f'); break;
                        case 0x67: text.Append('g'); break;
                        case 0x68: text.Append('h'); break;
                        case 0x69: text.Append('i'); break;
                        case 0x6A: text.Append('j'); break;
                        case 0x6B: text.Append('k'); break;
                        case 0x6C: text.Append('l'); break;
                        case 0x6D: text.Append('m'); break;
                        case 0x6E: text.Append('n'); break;
                        case 0x6F: text.Append('o'); break;

                        case 0x70: text.Append('p'); break;
                        case 0x71: text.Append('q'); break;
                        case 0x72: text.Append('r'); break;
                        case 0x73: text.Append('s'); break;
                        case 0x74: text.Append('t'); break;
                        case 0x75: text.Append('u'); break;
                        case 0x76: text.Append('v'); break;
                        case 0x77: text.Append('w'); break;
                        case 0x78: text.Append('x'); break;
                        case 0x79: text.Append('y'); break;
                        case 0x7A: text.Append('z'); break;
                        case 0x7B: text.Append('{'); break;
                        case 0x7C: text.Append('|'); break;
                        case 0x7D: text.Append('}'); break;
                        case 0x7E: text.Append('~'); break;
                        case 0x7F: text.Append(' '); break;

                        case 0x80: text.Append('Ђ'); break;
                        case 0x81: text.Append('Ѓ'); break;
                        case 0x82: text.Append('‚'); break;
                        case 0x83: text.Append('ѓ'); break;
                        case 0x84: text.Append('„'); break;
                        case 0x85: text.Append('…'); break;
                        case 0x86: text.Append('†'); break;
                        case 0x87: text.Append('‡'); break;
                        case 0x88: text.Append('€'); break;
                        case 0x89: text.Append('‰'); break;
                        case 0x8A: text.Append('Љ'); break;
                        case 0x8B: text.Append('‹'); break;
                        case 0x8C: text.Append('Њ'); break;
                        case 0x8D: text.Append('Ќ'); break;
                        case 0x8E: text.Append('Ћ'); break;
                        case 0x8F: text.Append('Џ'); break;

                        case 0x90: text.Append('ђ'); break;
                        case 0x91: text.Append('‘'); break;
                        case 0x92: text.Append('’'); break;
                        case 0x93: text.Append('“'); break;
                        case 0x94: text.Append('”'); break;
                        case 0x95: text.Append('•'); break;
                        case 0x96: text.Append('–'); break;
                        case 0x97: text.Append('—'); break;
                        case 0x98: text.Append(' '); break;
                        case 0x99: text.Append('™'); break;
                        case 0x9A: text.Append('љ'); break;
                        case 0x9B: text.Append('›'); break;
                        case 0x9C: text.Append('њ'); break;
                        case 0x9D: text.Append('ќ'); break;
                        case 0x9E: text.Append('ћ'); break;
                        case 0x9F: text.Append('џ'); break;

                        case 0xA0: text.Append(' '); break;
                        case 0xA1: text.Append('Ў'); break;
                        case 0xA2: text.Append('ў'); break;
                        case 0xA3: text.Append('Ј'); break;
                        case 0xA4: text.Append('¤'); break;
                        case 0xA5: text.Append('Ґ'); break;
                        case 0xA6: text.Append('¦'); break;
                        case 0xA7: text.Append('§'); break;
                        case 0xA8: text.Append('Ё'); break;
                        case 0xA9: text.Append('©'); break;
                        case 0xAA: text.Append('Є'); break;
                        case 0xAB: text.Append('«'); break;
                        case 0xAC: text.Append('¬'); break;
                        case 0xAD: text.Append(' '); break;
                        case 0xAE: text.Append('®'); break;
                        case 0xAF: text.Append('Ї'); break;

                        case 0xB0: text.Append('°'); break;
                        case 0xB1: text.Append('±'); break;
                        case 0xB2: text.Append('І'); break;
                        case 0xB3: text.Append('і'); break;
                        case 0xB4: text.Append('ґ'); break;
                        case 0xB5: text.Append('µ'); break;
                        case 0xB6: text.Append('¶'); break;
                        case 0xB7: text.Append('·'); break;
                        case 0xB8: text.Append('ё'); break;
                        case 0xB9: text.Append('№'); break;
                        case 0xBA: text.Append('є'); break;
                        case 0xBB: text.Append('»'); break;
                        case 0xBC: text.Append('ј'); break;
                        case 0xBD: text.Append('Ѕ'); break;
                        case 0xBE: text.Append('ѕ'); break;
                        case 0xBF: text.Append('ї'); break;

                        case 0xC0: text.Append('А'); break;
                        case 0xC1: text.Append('Б'); break;
                        case 0xC2: text.Append('В'); break;
                        case 0xC3: text.Append('Г'); break;
                        case 0xC4: text.Append('Д'); break;
                        case 0xC5: text.Append('Е'); break;
                        case 0xC6: text.Append('Ж'); break;
                        case 0xC7: text.Append('З'); break;
                        case 0xC8: text.Append('И'); break;
                        case 0xC9: text.Append('Й'); break;
                        case 0xCA: text.Append('К'); break;
                        case 0xCB: text.Append('Л'); break;
                        case 0xCC: text.Append('М'); break;
                        case 0xCD: text.Append('Н'); break;
                        case 0xCE: text.Append('О'); break;
                        case 0xCF: text.Append('П'); break;

                        case 0xD0: text.Append('Р'); break;
                        case 0xD1: text.Append('С'); break;
                        case 0xD2: text.Append('Т'); break;
                        case 0xD3: text.Append('У'); break;
                        case 0xD4: text.Append('Ф'); break;
                        case 0xD5: text.Append('Х'); break;
                        case 0xD6: text.Append('Ц'); break;
                        case 0xD7: text.Append('Ч'); break;
                        case 0xD8: text.Append('Ш'); break;
                        case 0xD9: text.Append('Щ'); break;
                        case 0xDA: text.Append('Ъ'); break;
                        case 0xDB: text.Append('Ы'); break;
                        case 0xDC: text.Append('Ь'); break;
                        case 0xDD: text.Append('Э'); break;
                        case 0xDE: text.Append('Ю'); break;
                        case 0xDF: text.Append('Я'); break;

                        case 0xE0: text.Append('а'); break;
                        case 0xE1: text.Append('б'); break;
                        case 0xE2: text.Append('в'); break;
                        case 0xE3: text.Append('г'); break;
                        case 0xE4: text.Append('д'); break;
                        case 0xE5: text.Append('е'); break;
                        case 0xE6: text.Append('ж'); break;
                        case 0xE7: text.Append('з'); break;
                        case 0xE8: text.Append('и'); break;
                        case 0xE9: text.Append('й'); break;
                        case 0xEA: text.Append('к'); break;
                        case 0xEB: text.Append('л'); break;
                        case 0xEC: text.Append('м'); break;
                        case 0xED: text.Append('н'); break;
                        case 0xEE: text.Append('о'); break;
                        case 0xEF: text.Append('п'); break;

                        case 0xF0: text.Append('р'); break;
                        case 0xF1: text.Append('с'); break;
                        case 0xF2: text.Append('т'); break;
                        case 0xF3: text.Append('у'); break;
                        case 0xF4: text.Append('ф'); break;
                        case 0xF5: text.Append('х'); break;
                        case 0xF6: text.Append('ц'); break;
                        case 0xF7: text.Append('ч'); break;
                        case 0xF8: text.Append('ш'); break;
                        case 0xF9: text.Append('щ'); break;
                        case 0xFA: text.Append('ъ'); break;
                        case 0xFB: text.Append('ы'); break;
                        case 0xFC: text.Append('ь'); break;
                        case 0xFD: text.Append('э'); break;
                        case 0xFE: text.Append('ю'); break;
                        case 0xFF: text.Append('я'); break;

                        default: text.Append(' '); break;
                    }
                    ++index;
                }
            }
            return text.ToString();
        }

        
        [SuppressUnmanagedCodeSecurity]
        unsafe public static void WriteASCIIString(FileWriter writer, string value, int length, bool isLastNull)
        {
            byte[] bytes = new byte[length];
            fixed (byte* pBytes = bytes)
            {
                if (value != null)
                {
                    char[] chars = value.ToCharArray();
                    int copyLength = chars.Length;
                    if (copyLength > 0)
                    {
                        if (copyLength > length)
                        {
                            copyLength = length;
                        }
                        fixed (char* pChars = chars)
                        {
                            for (int i = 0; i != copyLength; ++i)
                            {
                                switch (pChars[i])
                                {
                                    case ' ': pBytes[i] = 0x20; break;
                                    case '!': pBytes[i] = 0x21; break;
                                    case '\"': pBytes[i] = 0x22; break;
                                    case '#': pBytes[i] = 0x23; break;
                                    case '$': pBytes[i] = 0x24; break;
                                    case '%': pBytes[i] = 0x25; break;
                                    case '&': pBytes[i] = 0x26; break;
                                    case '\'': pBytes[i] = 0x27; break;
                                    case '(': pBytes[i] = 0x28; break;
                                    case ')': pBytes[i] = 0x29; break;
                                    case '*': pBytes[i] = 0x2A; break;
                                    case '+': pBytes[i] = 0x2B; break;
                                    case ',': pBytes[i] = 0x2C; break;
                                    case '-': pBytes[i] = 0x2D; break;
                                    case '.': pBytes[i] = 0x2E; break;
                                    case '/': pBytes[i] = 0x2F; break;

                                    case '0': pBytes[i] = 0x30; break;
                                    case '1': pBytes[i] = 0x31; break;
                                    case '2': pBytes[i] = 0x32; break;
                                    case '3': pBytes[i] = 0x33; break;
                                    case '4': pBytes[i] = 0x34; break;
                                    case '5': pBytes[i] = 0x35; break;
                                    case '6': pBytes[i] = 0x36; break;
                                    case '7': pBytes[i] = 0x37; break;
                                    case '8': pBytes[i] = 0x38; break;
                                    case '9': pBytes[i] = 0x39; break;
                                    case ':': pBytes[i] = 0x3A; break;
                                    case ';': pBytes[i] = 0x3B; break;
                                    case '<': pBytes[i] = 0x3C; break;
                                    case '=': pBytes[i] = 0x3D; break;
                                    case '>': pBytes[i] = 0x3E; break;
                                    case '?': pBytes[i] = 0x3F; break;

                                    case '@': pBytes[i] = 0x40; break;
                                    case 'A': pBytes[i] = 0x41; break;
                                    case 'B': pBytes[i] = 0x42; break;
                                    case 'C': pBytes[i] = 0x43; break;
                                    case 'D': pBytes[i] = 0x44; break;
                                    case 'E': pBytes[i] = 0x45; break;
                                    case 'F': pBytes[i] = 0x46; break;
                                    case 'G': pBytes[i] = 0x47; break;
                                    case 'H': pBytes[i] = 0x48; break;
                                    case 'I': pBytes[i] = 0x49; break;
                                    case 'J': pBytes[i] = 0x4A; break;
                                    case 'K': pBytes[i] = 0x4B; break;
                                    case 'L': pBytes[i] = 0x4C; break;
                                    case 'M': pBytes[i] = 0x4D; break;
                                    case 'N': pBytes[i] = 0x4E; break;
                                    case 'O': pBytes[i] = 0x4F; break;

                                    case 'P': pBytes[i] = 0x50; break;
                                    case 'Q': pBytes[i] = 0x51; break;
                                    case 'R': pBytes[i] = 0x52; break;
                                    case 'S': pBytes[i] = 0x53; break;
                                    case 'T': pBytes[i] = 0x54; break;
                                    case 'U': pBytes[i] = 0x55; break;
                                    case 'V': pBytes[i] = 0x56; break;
                                    case 'W': pBytes[i] = 0x57; break;
                                    case 'X': pBytes[i] = 0x58; break;
                                    case 'Y': pBytes[i] = 0x59; break;
                                    case 'Z': pBytes[i] = 0x5A; break;
                                    case '[': pBytes[i] = 0x5B; break;
                                    case '\\': pBytes[i] = 0x5C; break;
                                    case ']': pBytes[i] = 0x5D; break;
                                    case '^': pBytes[i] = 0x5E; break;
                                    case '_': pBytes[i] = 0x5F; break;

                                    case '`': pBytes[i] = 0x60; break;
                                    case 'a': pBytes[i] = 0x61; break;
                                    case 'b': pBytes[i] = 0x62; break;
                                    case 'c': pBytes[i] = 0x63; break;
                                    case 'd': pBytes[i] = 0x64; break;
                                    case 'e': pBytes[i] = 0x65; break;
                                    case 'f': pBytes[i] = 0x66; break;
                                    case 'g': pBytes[i] = 0x67; break;
                                    case 'h': pBytes[i] = 0x68; break;
                                    case 'i': pBytes[i] = 0x69; break;
                                    case 'j': pBytes[i] = 0x6A; break;
                                    case 'k': pBytes[i] = 0x6B; break;
                                    case 'l': pBytes[i] = 0x6C; break;
                                    case 'm': pBytes[i] = 0x6D; break;
                                    case 'n': pBytes[i] = 0x6E; break;
                                    case 'o': pBytes[i] = 0x6F; break;

                                    case 'p': pBytes[i] = 0x70; break;
                                    case 'q': pBytes[i] = 0x71; break;
                                    case 'r': pBytes[i] = 0x72; break;
                                    case 's': pBytes[i] = 0x73; break;
                                    case 't': pBytes[i] = 0x74; break;
                                    case 'u': pBytes[i] = 0x75; break;
                                    case 'v': pBytes[i] = 0x76; break;
                                    case 'w': pBytes[i] = 0x77; break;
                                    case 'x': pBytes[i] = 0x78; break;
                                    case 'y': pBytes[i] = 0x79; break;
                                    case 'z': pBytes[i] = 0x7A; break;
                                    case '{': pBytes[i] = 0x7B; break;
                                    case '|': pBytes[i] = 0x7C; break;
                                    case '}': pBytes[i] = 0x7D; break;
                                    case '~': pBytes[i] = 0x7E; break;

                                    case 'Ђ': pBytes[i] = 0x80; break;
                                    case 'Ѓ': pBytes[i] = 0x81; break;
                                    case '‚': pBytes[i] = 0x82; break;
                                    case 'ѓ': pBytes[i] = 0x83; break;
                                    case '„': pBytes[i] = 0x84; break;
                                    case '…': pBytes[i] = 0x85; break;
                                    case '†': pBytes[i] = 0x86; break;
                                    case '‡': pBytes[i] = 0x87; break;
                                    case '€': pBytes[i] = 0x88; break;
                                    case '‰': pBytes[i] = 0x89; break;
                                    case 'Љ': pBytes[i] = 0x8A; break;
                                    case '‹': pBytes[i] = 0x8B; break;
                                    case 'Њ': pBytes[i] = 0x8C; break;
                                    case 'Ќ': pBytes[i] = 0x8D; break;
                                    case 'Ћ': pBytes[i] = 0x8E; break;
                                    case 'Џ': pBytes[i] = 0x8F; break;

                                    case 'ђ': pBytes[i] = 0x90; break;
                                    case '‘': pBytes[i] = 0x91; break;
                                    case '’': pBytes[i] = 0x92; break;
                                    case '“': pBytes[i] = 0x93; break;
                                    case '”': pBytes[i] = 0x94; break;
                                    case '•': pBytes[i] = 0x95; break;
                                    case '–': pBytes[i] = 0x96; break;
                                    case '—': pBytes[i] = 0x97; break;
                                    case '™': pBytes[i] = 0x99; break;
                                    case 'љ': pBytes[i] = 0x9A; break;
                                    case '›': pBytes[i] = 0x9B; break;
                                    case 'њ': pBytes[i] = 0x9C; break;
                                    case 'ќ': pBytes[i] = 0x9D; break;
                                    case 'ћ': pBytes[i] = 0x9E; break;
                                    case 'џ': pBytes[i] = 0x9F; break;

                                    case 'Ў': pBytes[i] = 0xA1; break;
                                    case 'ў': pBytes[i] = 0xA2; break;
                                    case 'Ј': pBytes[i] = 0xA3; break;
                                    case '¤': pBytes[i] = 0xA4; break;
                                    case 'Ґ': pBytes[i] = 0xA5; break;
                                    case '¦': pBytes[i] = 0xA6; break;
                                    case '§': pBytes[i] = 0xA7; break;
                                    case 'Ё': pBytes[i] = 0xA8; break;
                                    case '©': pBytes[i] = 0xA9; break;
                                    case 'Є': pBytes[i] = 0xAA; break;
                                    case '«': pBytes[i] = 0xAB; break;
                                    case '¬': pBytes[i] = 0xAC; break;
                                    case '®': pBytes[i] = 0xAE; break;
                                    case 'Ї': pBytes[i] = 0xAF; break;

                                    case '°': pBytes[i] = 0xB0; break;
                                    case '±': pBytes[i] = 0xB1; break;
                                    case 'І': pBytes[i] = 0xB2; break;
                                    case 'і': pBytes[i] = 0xB3; break;
                                    case 'ґ': pBytes[i] = 0xB4; break;
                                    case 'µ': pBytes[i] = 0xB5; break;
                                    case '¶': pBytes[i] = 0xB6; break;
                                    case '·': pBytes[i] = 0xB7; break;
                                    case 'ё': pBytes[i] = 0xB8; break;
                                    case '№': pBytes[i] = 0xB9; break;
                                    case 'є': pBytes[i] = 0xBA; break;
                                    case '»': pBytes[i] = 0xBB; break;
                                    case 'ј': pBytes[i] = 0xBC; break;
                                    case 'Ѕ': pBytes[i] = 0xBD; break;
                                    case 'ѕ': pBytes[i] = 0xBE; break;
                                    case 'ї': pBytes[i] = 0xBF; break;

                                    case 'А': pBytes[i] = 0xC0; break;
                                    case 'Б': pBytes[i] = 0xC1; break;
                                    case 'В': pBytes[i] = 0xC2; break;
                                    case 'Г': pBytes[i] = 0xC3; break;
                                    case 'Д': pBytes[i] = 0xC4; break;
                                    case 'Е': pBytes[i] = 0xC5; break;
                                    case 'Ж': pBytes[i] = 0xC6; break;
                                    case 'З': pBytes[i] = 0xC7; break;
                                    case 'И': pBytes[i] = 0xC8; break;
                                    case 'Й': pBytes[i] = 0xC9; break;
                                    case 'К': pBytes[i] = 0xCA; break;
                                    case 'Л': pBytes[i] = 0xCB; break;
                                    case 'М': pBytes[i] = 0xCC; break;
                                    case 'Н': pBytes[i] = 0xCD; break;
                                    case 'О': pBytes[i] = 0xCE; break;
                                    case 'П': pBytes[i] = 0xCF; break;

                                    case 'Р': pBytes[i] = 0xD0; break;
                                    case 'С': pBytes[i] = 0xD1; break;
                                    case 'Т': pBytes[i] = 0xD2; break;
                                    case 'У': pBytes[i] = 0xD3; break;
                                    case 'Ф': pBytes[i] = 0xD4; break;
                                    case 'Х': pBytes[i] = 0xD5; break;
                                    case 'Ц': pBytes[i] = 0xD6; break;
                                    case 'Ч': pBytes[i] = 0xD7; break;
                                    case 'Ш': pBytes[i] = 0xD8; break;
                                    case 'Щ': pBytes[i] = 0xD9; break;
                                    case 'Ъ': pBytes[i] = 0xDA; break;
                                    case 'Ы': pBytes[i] = 0xDB; break;
                                    case 'Ь': pBytes[i] = 0xDC; break;
                                    case 'Э': pBytes[i] = 0xDD; break;
                                    case 'Ю': pBytes[i] = 0xDE; break;
                                    case 'Я': pBytes[i] = 0xDF; break;

                                    case 'а': pBytes[i] = 0xE0; break;
                                    case 'б': pBytes[i] = 0xE1; break;
                                    case 'в': pBytes[i] = 0xE2; break;
                                    case 'г': pBytes[i] = 0xE3; break;
                                    case 'д': pBytes[i] = 0xE4; break;
                                    case 'е': pBytes[i] = 0xE5; break;
                                    case 'ж': pBytes[i] = 0xE6; break;
                                    case 'з': pBytes[i] = 0xE7; break;
                                    case 'и': pBytes[i] = 0xE8; break;
                                    case 'й': pBytes[i] = 0xE9; break;
                                    case 'к': pBytes[i] = 0xEA; break;
                                    case 'л': pBytes[i] = 0xEB; break;
                                    case 'м': pBytes[i] = 0xEC; break;
                                    case 'н': pBytes[i] = 0xED; break;
                                    case 'о': pBytes[i] = 0xEE; break;
                                    case 'п': pBytes[i] = 0xEF; break;

                                    case 'р': pBytes[i] = 0xF0; break;
                                    case 'с': pBytes[i] = 0xF1; break;
                                    case 'т': pBytes[i] = 0xF2; break;
                                    case 'у': pBytes[i] = 0xF3; break;
                                    case 'ф': pBytes[i] = 0xF4; break;
                                    case 'х': pBytes[i] = 0xF5; break;
                                    case 'ц': pBytes[i] = 0xF6; break;
                                    case 'ч': pBytes[i] = 0xF7; break;
                                    case 'ш': pBytes[i] = 0xF8; break;
                                    case 'щ': pBytes[i] = 0xF9; break;
                                    case 'ъ': pBytes[i] = 0xFA; break;
                                    case 'ы': pBytes[i] = 0xFB; break;
                                    case 'ь': pBytes[i] = 0xFC; break;
                                    case 'э': pBytes[i] = 0xFD; break;
                                    case 'ю': pBytes[i] = 0xFE; break;
                                    case 'я': pBytes[i] = 0xFF; break;

                                    default: pBytes[i] = 0x20; break;
                                }
                            }
                        }
                        if (copyLength < length)
                        {
                            for (int i = copyLength; i != length; ++i)
                            {
                                pBytes[i] = 0;
                            }
                        }
                    }
                }
                if (isLastNull)
                {
                    pBytes[length - 1] = 0;
                }
            }
            writer.Write(bytes, 0, length);
        }
    }
}