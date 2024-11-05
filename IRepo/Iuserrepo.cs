using E_commers_project.Data;
using E_commers_project.DTOs;

namespace E_commers_project.IRepo
{
    public interface Iuserrepo
    {
        public IEnumerable<Users> Getallusers();
        public Users Getuserbyid(int id);
        public void Deletuser(int id);
        public void Adduser(userdto userdto);
        public void Updateuser(userdto userdto,int id);
    }
}
