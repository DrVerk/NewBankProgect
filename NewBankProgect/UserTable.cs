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
    
    public partial class UserTable
    {
        public UserTable(string username, int useraccauntid)
        {
            Username = username;
            Useraccauntid = useraccauntid;
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public int Useraccauntid { get; set; }
    }
}
