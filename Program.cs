using System;

namespace compteBanquaire
{
    class compte
    {
        //atributs 
        private int id;
        private string name;
        private int balance;
        private int overdraft;
        public compte (int _Id, string _Name, int _Balance, int _Overdraft)
        {
            id =_Id;
            name = _Name;
            balance = _Balance;
            overdraft = _Overdraft;
        }
        public compte ()
        {
            Random numero = new Random();
            this.id = numero.Next(0, 100000);
            this.name = "indéterminé";
            this.balance = 0;
            this.overdraft = 0;
        }
        public override string ToString()
        {
           return "Id : " + this.id + "\nNom : " + this.name + "\nSolde : " + this.balance + "\nDécouvert autorisé : " + this.overdraft;
        }
        public void crediter(int _amount)
        {
            this.balance += _amount;
        }
        public bool debiter(int _amount)
        {
            if (balance - _amount < overdraft)
            {
                return false;
            }
            else
            {
                this.balance -= _amount;
                return true;
            }
        }
        public int GetBalance()
        {
            return this.balance;
        }
        public bool virement(compte account, int _amount)
        {

            if (balance - _amount < overdraft)
            {
                return false;
            }
            else
            {
                this.balance -= _amount;
                account.crediter(_amount);
                return true;
            }
        }
    }
    class program
    {
        static void Main()
        {
            compte client1 = new compte(12345, "Chems hoflack", 1000, -100);
            compte client2 = new compte(22345, "Machin Truc", 5000, -100);
            client1.virement(client2, 100);
            Console.WriteLine(client1.ToString());
            Console.WriteLine(client2.ToString());
        }
    }
}

