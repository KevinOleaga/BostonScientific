using BostonScientific.DAL.Interfaces;
using BostonScientific.DAL.Metodos;
using System;

namespace BostonScientific.UI
{
    public partial class MyProfile : System.Web.UI.Page
    {
        public IUsers users;
        public MyProfile()
        {
            users = new MUsers();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            var res = users.UserInfo(Context.User.Identity.Name);
            
            email.Text = res[0].Email;
            user.Text = res[0].FirstName + " " + res[0].LastName;
            last_time.Text = res[0].LastTime;
            role.Text = res[0].IdRole;
            tel.Text = res[0].Telephone;

//            PocoDB.SearchUsers();
        }

        protected void Search_Click(object sender, EventArgs e)
        {
  /*          Debug.WriteLine("\nDato Capturado: " + search.Value + "\n");
            search.Value = "";
    */    }

        public void Miembros()
        {
      /*      int cant = Convert.ToInt32(PocoDB.CountUsers());
            string[] UsersContent = new string[cant];
            int sum = 0, sum1 = 1;

            Random rnd = new Random();

            UsersContent = PocoDB.SearchUsers();
            for (int i = 0; i < cant; i++)
            {
                Response.Write("<li>" +
                                   "<div class='row'> " +
                                       "<div class='col-xs-3'>" +
                                           "<div class='avatar'>" +
                                               "<img src='images/user" + rnd.Next(1, 5) + ".png' class='img-circle img-no-padding img-responsive custom_10'>" +
                                           "</div>" +
                                       "</div>" +

                                       "<div class='col-xs-6'>" +
                                           PocoDB.Capitalize(UsersContent[sum]) + "<br />" +
                                           "<span class='text-success'><small class='custom_11'>" + UsersContent[sum1] + "</small></span>" +
                                       "</div>" +

                                       "<div class='col-xs-3 text-right'>" +
                                           "<btn class='btn btn-sm btn-success btn-icon'><i class='fa fa-envelope'></i></btn>" +
                                       "</div>" +
                                   "</div>" +
                               "</li>");
                sum = sum + 2;
                sum1 = sum1 + 2;
            }
        */}

        protected void UpdateProfile(object sender, EventArgs e)
        {
          /*  PocoDB.UpdateProfile();
       */ }
    }
}