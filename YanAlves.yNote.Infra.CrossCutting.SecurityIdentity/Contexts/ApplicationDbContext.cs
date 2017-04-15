using System;
using YanAlves.yNote.Infra.CrossCutting.Security.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace YanAlves.yNote.Infra.CrossCutting.Security.Contexts
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IDisposable
    {
        public ApplicationDbContext()
            : base("yNoteUsersDb", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}