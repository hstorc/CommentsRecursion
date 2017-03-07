using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class Program
    {
        /*optional comment structure*/
        public class Comment {
            public int postId {get;set;}
            public int commentId { get; set; }
            public string comment { get; set; }
            public int? parentId { get; set; }
        }

        /*mock up comments list*/
        public List<Comment> GetComments() {
            List<Comment> comments = new List<Comment>();
            comments.Add(new Comment{ postId= 1,commentId= 1,comment= "comment 1", parentId= null });
            comments.Add(new Comment { postId = 1, commentId = 2, comment = "comment 2 to 1", parentId = 1 });
            comments.Add(new Comment { postId = 1, commentId = 3, comment = "comment 3 to 1", parentId = 1 });
            comments.Add(new Comment { postId = 1, commentId = 4, comment = "comment 4 to 2", parentId = 2 });
            comments.Add(new Comment { postId = 1, commentId = 5, comment = "comment 5 to 3", parentId = 3 });
            comments.Add(new Comment { postId = 1, commentId = 6, comment = "comment 6", parentId = null });
            return comments;
          }
        
        static void Main(string[] args)
        {
            Program p = new Program();
            List<Comment> comments = p.GetComments();
            DisplayComments(comments,null,1);
            Console.ReadLine();
        }

        /*recursive iteration through the comments list
         Stop when there is no more children for the current comment,
         Otherwise display a cooment and loop through its children 
         to find their children and on..*/
        private static void DisplayComments(List<Comment> comments, int? i, int level)
        {
            List<Comment> _coms = comments.Where(c => c.parentId == i).ToList();
            if (_coms.Count() == 0) {
                return;
            }
            foreach (Comment c in _coms)
            {   
                Console.WriteLine(">".Multiply(level)+c.comment);
                DisplayComments(comments, c.commentId, level+1);
             }
         }
    }

    /*just to make it visually understood*/
    public static class StringExtension
    {
        public static string Multiply(this string s, int i) {
            string q="";
            for (int x = 0; x < i; x++)
            {
                q += s;
            }
            return q;
            
        }
    }
    }
