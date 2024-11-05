using E_commers_project.Data;
using E_commers_project.DTOs;

namespace E_commers_project.IRepo
{
    public interface Isellerrepo
    {
      public  IEnumerable<Sellers> GetAllSellers();
      public  Sellers GetSellersbyid(int id);
      public void Deleteserller(int id);
      public void Addseller(sellerdto sellerdto);
      public void Updateserller(sellerdto sellerdto, int id);
    }
}
