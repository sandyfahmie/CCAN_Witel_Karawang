using System;
using System.Linq;
using CCAN_Witel_Karawang.Models.DB;
using CCAN_Witel_Karawang.Models.ViewModel;
using DevOne.Security.Cryptography.BCrypt;

namespace CCAN_Witel_Karawang.Models.EntityManager
{
    public class UserManager
    {
        public void AddUserAccount(UserSignUpView user)
        {
            using (dbccanEntities db = new dbccanEntities())
            {
                // Hashing password dengan Bcrypt
                string salt = BCryptHelper.GenerateSalt(6);
                var hashedPassword = BCryptHelper.HashPassword(user.Password, salt);

                SYSUser SU = new SYSUser();
                SU.NIK = user.NIK;
                SU.PasswordEncryptedText = hashedPassword;
                SU.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SU.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1; ;
                SU.RowCreatedDateTime = DateTime.Now;
                SU.RowModifiedDateTime = DateTime.Now;
                db.SYSUsers.Add(SU);
                db.SaveChanges();
                SYSUserProfile SUP = new SYSUserProfile();
                SUP.SYSUserID = SU.SYSUserID;
                SUP.NIK = SU.NIK;
                SUP.Name = user.Name;
                SUP.Gender = user.Gender;
                SUP.Division = user.Division;
                SUP.Phone = user.Phone;
                SUP.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                SUP.RowCreatedDateTime = DateTime.Now;
                SUP.RowModifiedDateTime = DateTime.Now;
                db.SYSUserProfiles.Add(SUP);
                db.SaveChanges();

                if (user.LOOKUPRoleID > 0)
                {
                    SYSUserRole SUR = new SYSUserRole();
                    SUR.LOOKUPRoleID = user.LOOKUPRoleID;
                    SUR.SYSUserID = user.SYSUserID;
                    SUR.IsActive = true;
                    SUR.RowCreatedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowModifiedSYSUserID = user.SYSUserID > 0 ? user.SYSUserID : 1;
                    SUR.RowCreatedDateTime = DateTime.Now;
                    SUR.RowModifiedDateTime = DateTime.Now;
                    db.SYSUserRoles.Add(SUR);
                    db.SaveChanges();
                }
            }
        }

        public bool IsLoginNameExist(string loginName)
        {
            using (dbccanEntities db = new dbccanEntities())
            {
                return db.SYSUsers.Where(o => o.NIK.Equals(loginName)).Any();
            }
        }

        // fungsi untuk melakukan penyamaan password dari user dgn yg ada di db 
        public bool IsPasswordMatch(string NIK, string password)
        {
            using (dbccanEntities db = new dbccanEntities())
            {
                var hashedPassword = GetUserPassword(NIK);
                return BCryptHelper.CheckPassword(password, hashedPassword);
            }
        }

        private static bool GetHashedPassword(string NIK, dbccanEntities db)
        {
            return db.SYSUsers.Where(o => o.NIK.Equals(NIK)).Any();
        }

        public string GetUserPassword(string NIK)
        {
            using (dbccanEntities db = new dbccanEntities())
            {
                var user = db.SYSUsers.Where(o => o.NIK.Equals(NIK));
                if (user.Any())
                    return user.FirstOrDefault().PasswordEncryptedText;
                else
                    return string.Empty;
            }
        }
    }
}