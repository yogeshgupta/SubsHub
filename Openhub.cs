/*
 *  SubsHub,an opensource subtitle downloader for movies and TV series.  
    Copyright (C) 2011  Yogesh Gupta

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with this program.  If not, see <http://www.gnu.org/licenses/>.
 * 
 */
using System;
using CookComputing.XmlRpc;

public struct LoginRequest
{
    public string token;
    public string status;
    public double seconds;
}

public struct LogoutRequest
{
    public string status;
    public double seconds;
}

public struct FileDet
{
   public string sublanguageid;
   public string moviehash;
   public double moviebytesize;
}

public struct DataReturn
{
   public string IDSubMovieFile;
   public string MovieHash;
   public string MovieByteSize;
   public string MovieTimeMS;
   public string IDSubtitleFile;
   public string SubFileName;
   public string SubActualCD;
   public string SubSize;
   public string SubHash;
   public string IDSubtitle;
   public string UserID;
   public string SubLanguageID;
   public string SubFormat;
   public string SubSumCD;
   public string SubAuthorComment;
   public string SubAddDate;
   public string SubBad;
   public string SubRating;
   public string SubDownloadsCnt;
   public string MovieReleaseName;
   public string IDMovie;
   public string IDMovieImdb;
   public string MovieName;
   public string MovieNameEng;
   public string MovieYear;
   public string MovieImdbRating;
   public string UserNickName;
   public string ISO639;
   public string LanguageName;
   public string SubDownloadLink;
   public string ZipDownloadLink;
}


public struct SubReturn
{
    public DataReturn[] data;
    public double seconds;
}

public struct SubTitlefl
{
    public string idsubtitlefile;
    public string data;
}
public struct Downsubs
{
    public string status;
    public SubTitlefl[] data;
    public double seconds;
}

public struct srchsubfilt
{

}

public struct Getsublangstrct
{
   public string SubLanguageID;
    public string LanguageName;
    public string ISO639;
}

public struct Getsublang
{
    public Getsublangstrct[] data;
    public double seconds; 
}


[XmlRpcUrl("http://api.opensubtitles.org/xml-rpc")]

public interface Opensubhub : IXmlRpcProxy
{
    

    [XmlRpcMethod("LogIn")]
    LoginRequest LogIn(string usename,string password,string language,string useragent);

    [XmlRpcMethod("LogOut")]
    LogoutRequest LogOut(string token);

    [XmlRpcMethod("SearchSubtitles")]
    SubReturn SearchSubtitles(string token, FileDet[] detail);

    [XmlRpcMethod("GetSubLanguages")]
    Getsublang GetSubLanguages(string language);
}


