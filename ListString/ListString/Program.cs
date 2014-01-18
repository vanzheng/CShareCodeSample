using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListString
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("1");
            string s = "INSERT INTO [PE_Comment](CommentId, GeneralId, TopicId, NodeId, CommentTitle, [Content], UpdateTime, Score, [Position], Status, Agree, Oppose, Neutral, IP, IsElite, IsPrivate, UserName, Face, Email, ReplyUserName) VALUES (@CommentId, @GeneralId, @TopicId, @NodeId, @CommentTitle, @Content, @UpdateTime, @Score, @Position, @Status, 0, 0, 0, @IP, 0, @IsPrivate, @UserName, @Face, @Email, @ReplyUserName";
            Console.WriteLine(list[0]);
            Console.Read();
        }
    }
}
