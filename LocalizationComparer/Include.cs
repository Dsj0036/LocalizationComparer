internal class Class43
{
    [global::System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = global::System.Runtime.InteropServices.CharSet.Auto, SetLastError = true)]
    [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.Bool)]
    private static extern bool CopyFileEx(string string_0, string string_1, global::Class43.Delegate1 delegate1_0, global::System.IntPtr intptr_0, ref int int_1, global::Class43.Enum6 enum6_0);

    public void method_0(string string_0, string string_1)
    {
        global::Class43.CopyFileEx(string_0, string_1, new global::Class43.Delegate1(this.method_1), global::System.IntPtr.Zero, ref this.int_0, (global::Class43.Enum6)10U);
    }

    private global::Class43.Enum4 method_1(long long_0, long long_1, long long_2, long long_3, uint uint_0, global::Class43.Enum5 enum5_0, global::System.IntPtr intptr_0, global::System.IntPtr intptr_1, global::System.IntPtr intptr_2)
    {
        return (global::Class43.Enum4)0U;
    }

    public Class43()
    {

    }

    private int int_0;

    private delegate global::Class43.Enum4 Delegate1(long TotalFileSize, long TotalBytesTransferred, long StreamSize, long StreamBytesTransferred, uint dwStreamNumber, global::Class43.Enum5 dwCallbackReason, global::System.IntPtr hSourceFile, global::System.IntPtr hDestinationFile, global::System.IntPtr lpData);

    private enum Enum4 : uint
    {

    }

    private enum Enum5 : uint
    {

    }

    [global::System.Flags]
    private enum Enum6 : uint
    {

    }
}

internal class Class47
{
    public Class47()
    {

        this.bool_0 = true;
    }

    public Class47(bool bool_1)
    {

        this.bool_0 = true;
        this.bool_0 = bool_1;
    }

    public bool method_0()
    {
        return this.bool_0;
    }

    public void method_1(bool bool_1)
    {
        this.bool_0 = bool_1;
    }

    internal short method_2(global::System.IO.Stream stream_0)
    {
        byte[] array = this.method_6(stream_0, 2);
        if (global::System.BitConverter.IsLittleEndian && this.method_0())
        {
            global::System.Array.Reverse(array);
        }
        return global::System.BitConverter.ToInt16(array, 0);
    }

    internal ushort method_3(global::System.IO.Stream stream_0)
    {
        byte[] array = this.method_6(stream_0, 2);
        if (global::System.BitConverter.IsLittleEndian && this.method_0())
        {
            global::System.Array.Reverse(array);
        }
        return global::System.BitConverter.ToUInt16(array, 0);
    }

    internal int method_4(global::System.IO.Stream stream_0)
    {
        byte[] array = this.method_6(stream_0, 4);
        if (global::System.BitConverter.IsLittleEndian && this.method_0())
        {
            global::System.Array.Reverse(array);
        }
        return global::System.BitConverter.ToInt32(array, 0);
    }

    internal uint method_5(global::System.IO.Stream stream_0)
    {
        byte[] array = this.method_6(stream_0, 4);
        if (global::System.BitConverter.IsLittleEndian && this.method_0())
        {
            global::System.Array.Reverse(array);
        }
        return global::System.BitConverter.ToUInt32(array, 0);
    }

    private byte[] method_6(global::System.IO.Stream stream_0, int int_0)
    {
        byte[] array = new byte[int_0];
        stream_0.Read(array, 0, int_0);
        return array;
    }

    internal string method_7(global::System.IO.Stream stream_0)
    {
        ushort num = this.method_3(stream_0);
        byte[] array = new byte[(int)num];
        for (int i = 0; i < (int)num; i++)
        {
            byte b = (byte)stream_0.ReadByte();
            array[i] = b;
        }
        global::System.Text.Encoding utf = global::System.Text.Encoding.UTF8;
        return utf.GetString(array);
    }

    internal int method_8(global::System.IO.Stream stream_0)
    {
        int result = this.method_4(stream_0);
        stream_0.Seek(-4L, global::System.IO.SeekOrigin.Current);
        return result;
    }

    internal void method_9(short short_0, global::System.IO.Stream stream_0)
    {
        byte[] bytes = global::System.BitConverter.GetBytes(short_0);
        if (global::System.BitConverter.IsLittleEndian && this.method_0())
        {
            global::System.Array.Reverse(bytes);
        }
        stream_0.Write(bytes, 0, bytes.Length);
    }

    internal void method_10(int int_0, global::System.IO.Stream stream_0)
    {
        byte[] bytes = global::System.BitConverter.GetBytes(int_0);
        if (global::System.BitConverter.IsLittleEndian && this.method_0())
        {
            global::System.Array.Reverse(bytes);
        }
        stream_0.Write(bytes, 0, bytes.Length);
    }

    internal void method_11(uint uint_0, global::System.IO.Stream stream_0)
    {
        byte[] bytes = global::System.BitConverter.GetBytes(uint_0);
        if (global::System.BitConverter.IsLittleEndian && this.method_0())
        {
            global::System.Array.Reverse(bytes);
        }
        stream_0.Write(bytes, 0, bytes.Length);
    }

    internal void method_12(string string_0, global::System.IO.MemoryStream memoryStream_0)
    {
        global::System.Text.Encoding utf = global::System.Text.Encoding.UTF8;
        byte[] bytes = utf.GetBytes(string_0);
        this.method_9((short)bytes.Length, memoryStream_0);
        memoryStream_0.Write(bytes, 0, bytes.Length);
    }

    private bool bool_0;
}

namespace Tweaker.Workers
{

    public class LOC
    {
    }

    public class LanguageBuilder
    {
        public void Build(LanguagesContainer languages, string path)
        {
            using (global::System.IO.BinaryWriter binaryWriter = new global::System.IO.BinaryWriter(global::System.IO.File.Open(path, global::System.IO.FileMode.Create)))
            {
                global::System.IO.Stream baseStream = binaryWriter.BaseStream;
                this.class47_0.method_10(2, baseStream);
                int count = languages.Languages.Count;
                this.class47_0.method_10(count, baseStream);
                baseStream.WriteByte(1);
                int num = languages.Indexes.Length;
                this.class47_0.method_10(num, baseStream);
                for (int i = 0; i < num; i++)
                {
                    this.class47_0.method_10(languages.Indexes[i], baseStream);
                }
                byte[] array = this.method_0(languages);
                baseStream.Write(array, 0, array.Length);
            }
        }

        private byte[] method_0(LanguagesContainer languagesContainer_0)
        {
            global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
            global::System.IO.MemoryStream memoryStream2 = new global::System.IO.MemoryStream();
            foreach (LanguageEntry languageEntry in languagesContainer_0.Languages.Values)
            {
                byte[] array = this.method_1(languageEntry);
                this.class47_0.method_12(languageEntry.Name, memoryStream);
                this.class47_0.method_10(array.Length, memoryStream);
                memoryStream2.Write(array, 0, array.Length);
            }
            global::System.IO.MemoryStream memoryStream3 = new global::System.IO.MemoryStream();
            byte[] array2 = memoryStream.ToArray();
            memoryStream3.Write(array2, 0, array2.Length);
            array2 = memoryStream2.ToArray();
            memoryStream3.Write(array2, 0, array2.Length);
            return memoryStream3.ToArray();
        }

        private byte[] method_1(LanguageEntry languageEntry_0)
        {
            global::System.IO.MemoryStream memoryStream = new global::System.IO.MemoryStream();
            memoryStream.WriteByte(0);
            this.class47_0.method_10(513, memoryStream);
            this.class47_0.method_12(languageEntry_0.Name, memoryStream);
            this.class47_0.method_10(languageEntry_0.Messages.Count, memoryStream);
            foreach (MessageEntry messageEntry in languageEntry_0.Messages)
            {
                this.class47_0.method_12(messageEntry.Message, memoryStream);
            }
            return memoryStream.ToArray();
        }

        public LanguageBuilder()
        {

            this.class47_0 = new global::Class47();

        }

        private global::Class47 class47_0;
    }

    public class LanguagesContainer
    {
        public int[] Indexes
        {
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            get
            {
                return this.int_0;
            }
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            set
            {
                this.int_0 = value;
            }
        }

        public global::System.Collections.Generic.Dictionary<string, LanguageEntry> Languages
        {
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            get
            {
                return this.dictionary_0;
            }
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            set
            {
                this.dictionary_0 = value;
            }
        }

        public LanguagesContainer()
        {


        }

        public LanguagesContainer(int[] indexes, global::System.Collections.Generic.Dictionary<string, LanguageEntry> languages)
        {


            this.Indexes = indexes;
            this.Languages = languages;
        }

        [global::System.Runtime.CompilerServices.CompilerGenerated]
        private int[] int_0;

        [global::System.Runtime.CompilerServices.CompilerGenerated]
        private global::System.Collections.Generic.Dictionary<string, LanguageEntry> dictionary_0;
    }

    public class LanguageEntry
    {
        public string Name
        {
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }

        public int Size
        {
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            get
            {
                return this.int_0;
            }
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            set
            {
                this.int_0 = value;
            }
        }

        public global::System.Collections.Generic.List<MessageEntry> Messages
        {
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            get
            {
                return this.list_0;
            }
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            set
            {
                this.list_0 = value;
            }
        }

        public LanguageEntry()
        {


        }

        public LanguageEntry(string name, int size)
        {


            this.Name = name;
            this.Size = size;
            this.Messages = new global::System.Collections.Generic.List<MessageEntry>();
        }

        [global::System.Runtime.CompilerServices.CompilerGenerated]
        private string string_0;

        [global::System.Runtime.CompilerServices.CompilerGenerated]
        private int int_0;

        [global::System.Runtime.CompilerServices.CompilerGenerated]
        private global::System.Collections.Generic.List<MessageEntry> list_0;
    }

    public class MessageEntry
    {
        public string Message
        {
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            get
            {
                return this.string_0;
            }
            [global::System.Runtime.CompilerServices.CompilerGenerated]
            set
            {
                this.string_0 = value;
            }
        }

        public MessageEntry()
        {

        }

        public MessageEntry(string message)
        {

            this.Message = message;
        }

        [global::System.Runtime.CompilerServices.CompilerGenerated]
        private string string_0;
    }

    public class IndexEntry
    {
        public IndexEntry()
        {


        }
    }

    public class LanguagesParser
    {
        public LanguagesContainer Parse(byte[] locData, Action<int, int> progress)
        {
            LanguagesContainer lc = new LanguagesContainer();
            global::System.IO.MemoryStream s = new global::System.IO.MemoryStream(locData);
            return this.Parse(lc, s, progress);
        }

        public LanguagesContainer Parse(string path, Action<int, int> progress)
        {
            LanguagesContainer languagesContainer = new LanguagesContainer();
            if (global::System.IO.File.Exists(path))
            {
                using (global::System.IO.BinaryReader binaryReader = new global::System.IO.BinaryReader(global::System.IO.File.Open(path, global::System.IO.FileMode.Open)))
                {
                    global::System.IO.Stream baseStream = binaryReader.BaseStream;
                    languagesContainer = this.Parse(languagesContainer, baseStream, progress);
                }
            }
            return languagesContainer;
        }

        public LanguagesContainer Parse(LanguagesContainer lc, global::System.IO.Stream s, Action<int, int> progress)
        {
            this.class47_0.method_4(s);
            int num = this.class47_0.method_4(s);
            s.ReadByte();
            int num2 = this.class47_0.method_4(s);
            int[] array = new int[num2];
            for (int i = 0; i < num2; i++)
            {
                array[i] = this.class47_0.method_4(s);
                progress(i, num2);
            }
            lc.Indexes = array;
            global::System.Collections.Generic.Dictionary<string, LanguageEntry> dictionary = new global::System.Collections.Generic.Dictionary<string, LanguageEntry>();
            for (int j = 0; j < num; j++)
            {
                string text = this.class47_0.method_7(s);
                int size = this.class47_0.method_4(s);
                LanguageEntry value = new LanguageEntry(text, size);
                dictionary.Add(text, value);

                progress(j, num);
            }
            for (int k = 0; k < num; k++)
            {
                s.ReadByte();
                this.class47_0.method_4(s);
                string key = this.class47_0.method_7(s);
                int num3 = this.class47_0.method_4(s);
                LanguageEntry languageEntry = dictionary[key];
                for (int l = 0; l < num3; l++)
                {
                    string message = this.class47_0.method_7(s);
                    languageEntry.Messages.Add(new MessageEntry(message));
                }
                progress(k, num);
            }
            lc.Languages = dictionary;
            return lc;
        }

        public LanguagesParser()
        {

            this.class47_0 = new global::Class47();

        }

        private global::Class47 class47_0;
    }
}
