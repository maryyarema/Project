using System;
internal class Comment
{
    public int id;
    public string coment;
    public int user_id;
    public int film_id;
    public User user; //звязок із табличкою users
}