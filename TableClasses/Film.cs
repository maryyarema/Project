using System;
internal class Film
{

    public int id;
    public string title;
    public string url;
    public int year;
    public string time;     
    public object rating;
    public int country_id;
    public int language_id;
    public int producer_id ;
    public int company_id;
    public Country country; //звязок із табличкою countries
    public Language language; //звязок із табличкою languages
    public Producer producer; //звязок із табличкою producers
    public Company company; //звязок із табличкою companies
    public List<Genre> genres; //звязок із табличкою genres
    public List<Comment> comments; //звязок із табличкою comments




}