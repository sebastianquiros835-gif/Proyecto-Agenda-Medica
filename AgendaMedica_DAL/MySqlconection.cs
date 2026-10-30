using System;

namespace AgendaMedica_DAL
{
    internal class MySqlconection
    {
        private string v;

        public MySqlconection(string v)
        {
            this.v = v;
        }

        internal void Close()
        {
            throw new NotImplementedException();
        }

        internal void Open()
        {
            throw new NotImplementedException();
        }
    }
}