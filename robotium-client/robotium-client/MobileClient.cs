using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace robotium_client
{
    public class MobileClient : MobileClientI
    {

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private RobotiumTcpClient tcpClient;

        public MobileClient(string host, int port)
        {
            tcpClient = new RobotiumTcpClient(host, port);
        }

        public CommandResponse Launch(string launcherActivityClass)
        {
            return SendData("launch", launcherActivityClass);
        }

        public CommandResponse GetTextView(int index)
        {
            return SendData("getTextView", index.ToString());
        }

        public CommandResponse GetTextViewIndex(string text)
        {
            return SendData("getTextViewIndex", text);
        }

        public CommandResponse GetCurrentTextViews()
        {
            return SendData("getCurrentTextViews", "a");
        }

        public CommandResponse GetText(int index)
        {
            return SendData("getText", index.ToString());
        }

        public CommandResponse ClickOnMenuItem(string item)
        {
            return SendData("clickOnMenuItem", item);
        }

        public CommandResponse ClickOnView(int index)
        {
            return SendData("clickOnView", index.ToString());
        }

        public CommandResponse EnterText(int index, string text)
        {
            return SendData("enterText", index.ToString(), text);
        }

        public CommandResponse ClickOnButton(int line)
        {
            return SendData("clickOnButton", line.ToString());
        }

        public CommandResponse ClearEditText(int index)
        {
            return SendData("clearEditText", index.ToString());
        }

        public CommandResponse ClickOnButtonWithText(string text)
        {
            return SendData("clickOnButtonWithText", text);
        }

        public CommandResponse ClickOnText(string text)
        {
            return SendData("clickOnText", text);
        }

        public CommandResponse ClickOnHardwareButton(Enums.HardwareButtons button)
        {
            return SendData("clickOnHardware", button.ToString());
        }

        public CommandResponse SendKey(int key)
        {
            return SendData("sendKey", key.ToString());
        }

        public void CloseConnection()
        {
            SendData("exit");
        }

        public CommandResponse GetViews()
        {
            return SendData("getViews");
        }

        public CommandResponse SwipeLeft()
        {
            return SendData("swipeLeft");
        }

        public CommandResponse SwipeRight()
        {
            return SendData("swipeRight");
        }

        public CommandResponse ClickOnImageButton(int index)
        {
            return SendData("clickOnImageButton", index.ToString());
        }

        public CommandResponse ClickOnImage(int index)
        {
            return SendData("clickOnImage", index.ToString());
        }

        public CommandResponse ScrollDown()
        {
            return SendData("scrollDown", new String[] { });
        }

        public CommandResponse IsTextVisible(string text)
        {
            return SendData("isTextVisible", new String[] { text });
        }

        public CommandResponse AssertTextVisible(String text)
        {
            return SendData("assertTextVisible", new String[] { text });
        }

        public CommandResponse ScrollDownUntilTextIsVisible(string text)
        {
            return SendData("scrollDownUntilTextIsVisible", new String[] { text });
        }

        public CommandResponse GetCurrentActivity()
        {
            return SendData("getCurrentActivity", new String[] { });
        }

        public CommandResponse ClickOnActionBarItem(int index)
        {
            return SendData("clickOnActionBarItem", new String[] { index.ToString() });
        }

        public CommandResponse ClickOnScreen(float x, float y, bool relative)
        {
            return SendData("clickOnScreen", new String[] { x.ToString(), y.ToString(),
				(relative ? "relative" : "absolute") });
        }

        public CommandResponse Drag(float fromX, float toX, float fromY, float toY, int steps, bool relative)
        {
            return SendData("drag",
                new String[] { fromX.ToString(), toX.ToString(), fromY.ToString(), toY.ToString(),
						steps.ToString(), (relative ? "relative" : "absolute") });
        }

        public CommandResponse SetOrientation(int orientation)
        {
            if (orientation == 0)
            {
                return SendData("setLandscapeOrientation");
            }
            else if (orientation == 1)
            {
                return SendData("setPortraitOrientation");
            }
            return null;
        }

        public CommandResponse ScrollToEdge(Enums.EDGE edge)
        {
            return SendData("scrollToEdge", new String[] { (edge == robotium_client.Enums.EDGE.TOP ? "top" : "bottom") });
        }

        public CommandResponse VerifyViewExistsByDescription(string description, bool click, bool startsWith, bool clickInSpecificPosition, float x, float y)
        {
            return SendData("verifyViewExistsByDescription", description, click.ToString(),
                startsWith.ToString(), clickInSpecificPosition.ToString(), x.ToString(),
                y.ToString());
        }

        public CommandResponse ClickInList(int index1, int index2)
        {
            return SendData("clickInList", index1.ToString(), index2.ToString());
        }

        public CommandResponse ClickInList(int index)
        {
            return SendData("clickInList", index.ToString());
        }

        public CommandResponse Click(string expression)
        {
            return SendData("click", expression);
        }

        public CommandResponse GetAllVisibleIds()
        {
            return SendData("getAllVisibleIds");
        }

        public CommandResponse WaitForActivity(string activity, int timeout)
        {
            return SendData("waitForActivity", activity, timeout.ToString());
        }

        public CommandResponse ClickOnWebElement(string by, string expression)
        {
            return SendData("clickOnWebElement", by, expression);
        }

        public CommandResponse EnterTextInWebElement(string by, string expression, string text)
        {
            return SendData("enterTextInWebElement", by, expression, text);
        }

        public string TakeScreenshot()
        {
            throw new NotImplementedException();
        }

        private CommandResponse SendData(String command, params string[] parameters)
        {
            CommandResponse result = null;
            try
            {
                result = SendDataAndGetJSonObj(new CommandRequest(command, parameters));
            }
            catch (Exception e)
            {
                log.Error("Failed to send / receive data");
                throw e;
            }
            return result;
        }


        private CommandResponse SendDataAndGetJSonObj(CommandRequest commandRequest)
        {

            string response = null;
            using (MemoryStream stream1 = new MemoryStream())
            using (StreamReader sr = new StreamReader(stream1))
            {
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(CommandRequest));
                    serializer.WriteObject(stream1, commandRequest);
                    stream1.Position = 0;
                    response = tcpClient.Send(sr.ReadToEnd());
                    if (null == response)
                    {
                        throw new Exception("Received no response from server");
                    }


                }

            }
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(CommandResponse));
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(response)))
            {
                CommandResponse result = (CommandResponse)deserializer.ReadObject(stream);
                return result;
            }

        }


    }
}
