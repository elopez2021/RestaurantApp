using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repositories
{
    internal interface ILoginRepository
    {
        (int?, bool, string, int, int?) Autheticate(string username, string password);
    }
}
