//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NewBankProgect
{
    using System;
    using System.Collections.Generic;
    
    public partial class Accaunt
    {
        public Accaunt(int accauntNumber, int kredit, int money, int stavka, int deposite)
        {
            AccauntNumber = accauntNumber;
            Kredit = kredit;
            Money = money;
            Stavka = stavka;
            Deposite = deposite;
        }

        public int Id { get; set; }
        public int AccauntNumber { get; set; }
        public int Kredit { get; set; }
        public int Money { get; set; }
        public int Stavka { get; set; }
        public int Deposite { get; set; }
    }
}