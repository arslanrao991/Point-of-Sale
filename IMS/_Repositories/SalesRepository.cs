using IMS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMS._Repositories
{
    internal class SalesRepository: BaseRepository, ISalesRepository
    {
        private string sqlConnectionString;

        public SalesRepository(string sqlConnectionString)
        {
            this.sqlConnectionString = sqlConnectionString;
        }
    }
}
