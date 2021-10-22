using MVCwithoutentity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCwithoutentity.Controllers
{
    public class StudentController : Controller
    {
        string connectionString = @"data source=101.53.146.129;initial catalog = tipltrainee; user id = trainee; password=tipl#789;MultipleActiveResultSets=True";
        [HttpGet]
        public ActionResult Index()
        {
            DataTable db = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Student_Trainee",sqlCon);
                sqlDa.Fill(db);
            }
            return View(db);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new StudentModel());
        }

        // POST: Student/Create
        [HttpPost]
        public ActionResult Create(StudentModel studentmodel)
        {
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                String query = " INSERT INTO Student_Trainee VALUES([name],[email],[gender],[dob])(@name,@email,@gender,@dob)";
                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                sqlCmd.Parameters.AddWithValue("@name", studentmodel.name);
                sqlCmd.Parameters.AddWithValue("@email", studentmodel.email);
                sqlCmd.Parameters.AddWithValue("@gender", studentmodel.gender);
                sqlCmd.Parameters.AddWithValue("@dob", studentmodel.dob);
                sqlCmd.ExecuteNonQuery();
            }
             return RedirectToAction("Index");
            
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            StudentModel studmodel = new StudentModel();
            DataTable dt = new DataTable();
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string query = "select * from Student_trainee where id=@id";
                SqlDataAdapter sqcmd = new SqlDataAdapter(query, sqlcon);
                sqcmd.SelectCommand.Parameters.AddWithValue("@id", id);
                sqcmd.Fill(dt);
            }
            if (dt.Rows.Count == 1)
            {
                studmodel.id = Convert.ToInt32(dt.Rows[0][0].ToString());
                studmodel.name = (dt.Rows[0]["name"].ToString());
                studmodel.email = (dt.Rows[0]["email"].ToString());
                studmodel.gender = (dt.Rows[0]["gender"].ToString());
                studmodel.dob = Convert.ToDateTime(dt.Rows[0]["dob"].ToString());
                return View(studmodel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        // POST: Stud/Edit/5
        [HttpPost]
        public ActionResult Edit(StudentModel studmodel)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string query = "update Student_Trainee SET name=@name,email=@email,gender=@gender,dob=@dob where id=@id";
                SqlCommand sqcmd = new SqlCommand(query, sqlcon);
                sqcmd.Parameters.AddWithValue("@id", studmodel.id);
                sqcmd.Parameters.AddWithValue("@name", studmodel.name);
                sqcmd.Parameters.AddWithValue("@email", studmodel.email);
                sqcmd.Parameters.AddWithValue("@gender", studmodel.gender);
                sqcmd.Parameters.AddWithValue("@dob", studmodel.dob);
                sqcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            using (SqlConnection sqlcon = new SqlConnection(connectionString))
            {
                sqlcon.Open();
                string query = "DELETE FROM Student_Trainee where id=@id";
                SqlCommand sqcmd = new SqlCommand(query, sqlcon);
                sqcmd.Parameters.AddWithValue("@id",id);
                sqcmd.ExecuteNonQuery();
            }
            return RedirectToAction("Index");
        }

       
        
    }
}
