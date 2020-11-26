using System;

namespace Project
{
    public class ModulPrincipal
    {
        private int _codModul;
        private int _lotRezistente;
        private int _lotCondensatoare;
        private DateTime _dateTime;
      
        public ModulPrincipal()
        {
            //Console.WriteLine("Am creat modul cu datele");
           
            _lotCondensatoare = 0;
            _lotRezistente = 0;
            _codModul = 0;
            _dateTime = DateTime.Now;
        }

        public DateTime GetDateTime()
        {
            return _dateTime;
        }

        public int getCodModul()
        {
            return _codModul;
        }

        public void setCodModul(int codNou)
        {
            _codModul = codNou;
        }

        public int getLotRezistente()
        {
            return _lotRezistente;
        }

        public void setLotRezistente(int codNou)
        {
            _lotRezistente = codNou;
        }

        public int getLotCondensatoare()
        {
            return _lotCondensatoare;
        }

        public void setLotCondensatoare(int codNou)
        {
            _lotCondensatoare = codNou;
        }

        public override string ToString()
        {
            return this.GetDateTime().ToString() + " " + this.getCodModul().ToString() + " " + this.getLotCondensatoare().ToString() + " " + this.getLotRezistente().ToString()+" ";
        }

        
    }
}
