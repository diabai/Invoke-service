using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Xml;
using System.Net;

/**
 * Simple web service to retrieve header content from a URI.
 * @Author: Ibrahim Diabate
 * @Version: January 18
 * */
namespace URLHeaders
{
    /// <summary>
    /// Summary description for CheckURLHeaders
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CheckURLHeaders : System.Web.Services.WebService
    {

        [WebMethod]
        public XmlDocument checkURL(String someURI)
        {
            
            XmlDocument dom = new XmlDocument();
            XmlElement responseHeadersTag = dom.CreateElement("ResponseHeaders");

            dom.AppendChild(responseHeadersTag);

            //Creating inner tags
            XmlElement statusCodeTag = dom.CreateElement("StatusCode");
            XmlElement protocolVersionTag = dom.CreateElement("ProtocolVersion");
            XmlElement serverTag = dom.CreateElement("Server");
            XmlElement lastModifiedTag = dom.CreateElement("LastModified");
            XmlElement characterSetTag = dom.CreateElement("CharacterSet");
            XmlElement contentTypeTag = dom.CreateElement("ContentType");
            XmlElement contentLengthTag = dom.CreateElement("contentLength");

            //Nesting
            responseHeadersTag.AppendChild(statusCodeTag);
            responseHeadersTag.AppendChild(protocolVersionTag);
            responseHeadersTag.AppendChild(serverTag);
            responseHeadersTag.AppendChild(lastModifiedTag);
            responseHeadersTag.AppendChild(characterSetTag);
            responseHeadersTag.AppendChild(contentTypeTag);
            responseHeadersTag.AppendChild(contentLengthTag);

            // Construct the HTTP Request
            HttpWebRequest serviceRequest = (HttpWebRequest)WebRequest.Create(someURI);
            serviceRequest.Method = "GET";
            serviceRequest.ContentType = "text/xml; charset=utf-8";

            // Send the HTTP request and analyze the HTTP Response
            // - create an instance of HTTPWebResponse & invoke GetResponse using serviceRequest

            HttpWebResponse serviceResponse = (HttpWebResponse)serviceRequest.GetResponse();

            if (serviceResponse.StatusCode == HttpStatusCode.OK)
            {
                // Load relevant values into the corresponding xml tags
                XmlText statusCodeTagText = dom.CreateTextNode(serviceResponse.StatusCode.ToString());
                statusCodeTag.AppendChild(statusCodeTagText);

                XmlText protocolVersionTagText = dom.CreateTextNode(serviceResponse.ProtocolVersion.ToString());
                protocolVersionTag.AppendChild(protocolVersionTagText);

                XmlText lastModifiedTagText = dom.CreateTextNode(serviceResponse.LastModified.ToString());
                lastModifiedTag.AppendChild(lastModifiedTagText);

                XmlText serverTagText = dom.CreateTextNode(serviceResponse.Server.ToString());
                serverTag.AppendChild(serverTagText);

                XmlText charSetTagText = dom.CreateTextNode(serviceResponse.CharacterSet.ToString());
                characterSetTag.AppendChild(charSetTagText);

                XmlText contentTypeTagText = dom.CreateTextNode(serviceResponse.ContentType.ToString());
                contentTypeTag.AppendChild(contentTypeTagText);

                XmlText contentLengthTagText = dom.CreateTextNode(serviceResponse.ContentLength.ToString());
                contentLengthTag.AppendChild(contentLengthTagText);

            }
            else
                Console.WriteLine("the response did not contain a HTTP Status 200");

            return dom;
        }
    }
}
