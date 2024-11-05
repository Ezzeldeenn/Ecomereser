using E_commers_project.Data;
using E_commers_project.DTOs;

namespace E_commers_project.IRepo
{
    public interface Iporductrepo
    {
        public IEnumerable<Products> Getallproduct();
        public Products Getproductbyid(int id);
        public void Deletproduct(int id);
        public void Addproduct(productdto productdto);
        public void Updataproduct(productdto productdto, int id);

    }
}
