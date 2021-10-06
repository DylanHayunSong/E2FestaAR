using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using UnityEngine;

public class FTPManager : MonoBehaviour
{
    [SerializeField]
    private string ftpServer;
    [SerializeField]
    private string ftpUserName;
    [SerializeField]
    private string ftpPassword;

    private void Start ()
    {
        EventManager.inst.FileUploadReq += FileUpload;
    }

    public void FileUpload (byte[] data)
    {
        string userName = UserDataManager.inst.GetUserData().userName;
        string userCompany = "_" + UserDataManager.inst.GetUserData().company + "_";
        string userContact = UserDataManager.inst.GetUserData().contact;
        string userMessage = UserDataManager.inst.GetUserData().message;
        string time = System.DateTime.Now.ToString("HH_mm_dd_MM");

        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpServer + "/" + time + userCompany + userName + ".png");
        request.Method = WebRequestMethods.Ftp.UploadFile;

        // This example assumes the FTP site uses anonymous logon.
        request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

        // Copy the contents of the file to the request stream.
        byte[] fileContents = data;

        request.ContentLength = fileContents.Length;

        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(fileContents, 0, fileContents.Length);
        }

        request = (FtpWebRequest)WebRequest.Create(ftpServer + "/" + time + userCompany + userName + ".txt");
        request.Method = WebRequestMethods.Ftp.UploadFile;
        request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);

        string newText = "Name : " + userName + "\n" + "University : " + userCompany + "\n" + "Contact : " + userContact + "\n" + "Message : " + userMessage;

        fileContents = Encoding.UTF8.GetBytes(newText);

        using (Stream requestStream = request.GetRequestStream())
        {
            requestStream.Write(fileContents, 0, fileContents.Length);
        }
    }
}
