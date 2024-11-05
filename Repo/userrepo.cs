using E_commers_project.Data;
using E_commers_project.DTOs;
using E_commers_project.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http.HttpResults;

namespace E_commers_project.Repo
{
    public class userrepo : Iuserrepo
    {
        private readonly AppDbContext _context;

        public userrepo(AppDbContext context)
        {
            _context = context;
        }

        public void Adduser(userdto userdto)
        {
            // Map userdto to Users entity
            var user = new Users
            {
                UserName = userdto.UserName,
                UserEmail = userdto.UserEmail,
                Userphone=userdto.Userphone,
                User_creadcard=userdto.User_creadcard,
                UserPassword=userdto.UserPassword,
                User_comfarm_pass=userdto.User_comfarm_pass,
            };
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void Deletuser(int id)
        {
            var user =  _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                 _context.SaveChanges();
            }
        }

        public IEnumerable<Users> Getallusers()
        {
            return _context.Users.ToList(); //we can use where    .OrderBy(u => u.UserId) to order it
        }

        public  Users Getuserbyid(int id)
        {
            var user = _context.Users.Find(id);
            return user;
        }

        public void  Updateuser(userdto userdto, int id)
        {
            var user =  _context.Users.FirstOrDefault(x=>x.UserId==id);
            if (user != null)
            {
                user.UserName = userdto.UserName;
                user.UserEmail = userdto.UserEmail;
                user.User_creadcard = userdto.User_creadcard;
                user.Userphone=userdto.Userphone;
                user.User_comfarm_pass=userdto.User_comfarm_pass;
                user.UserPassword=userdto.UserPassword;
                _context.SaveChanges();
            }
        }
    }
}
