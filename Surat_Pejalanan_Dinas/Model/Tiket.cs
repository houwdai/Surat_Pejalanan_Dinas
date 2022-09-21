using System;
using System.Collections.Generic;
using System.Text;

namespace Surat_Pejalanan_Dinas.Model
{
    public class Tiket
    {
        public int id { get; set; }
        public int harga { get; set; }    
        public string ruteAwal { get; set; }
        public string ruteTujuan { get; set; }  
    }
}
