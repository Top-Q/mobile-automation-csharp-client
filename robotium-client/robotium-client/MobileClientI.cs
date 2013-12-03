using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace robotium_client
{
    interface MobileClientI
    {

        /**
         * NOTE ! THIS METHOD MUST BE THE FIRST COMMAND BEFORE ANY OTHER COMMAND the
         * launch method will launch the instrumentation of the application
         * 
         * @param launcherActivityClass
         *            the full class name with the package of the main launcher
         *            activity
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse Launch(String launcherActivityClass);

        /**
         * will get the text of the input text view index
         * 
         * @param index
         *            the index of the text view on the screen
         * @return the text of the text view
         * @throws Exception
         */
        CommandResponse GetTextView(int index);

        /**
         * will get the id of the text view with the input text
         * 
         * @param text
         *            the text that is in the text view
         * @return id of the text view
         * @throws Exception
         */
        CommandResponse GetTextViewIndex(String text);

        /**
         * will get a list of all the texts of the current display text views
         * 
         * @return list of all the text views current displayed
         * @throws Exception
         */
        CommandResponse GetCurrentTextViews();

        /**
         * will get the text of the view by the input index
         * 
         * @param index
         *            the index of the view in the screen
         * @return the text of the input index text view
         * @throws Exception
         */
        CommandResponse GetText(int index);

        /**
         * will click on the menu item with the input text
         * 
         * @param item
         *            the text of the item in the menu
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse ClickOnMenuItem(String item);

        /**
         * will click on any view with the input index
         * 
         * @param index
         *            the index of the view on the screen
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse ClickOnView(int index);

        /**
         * will enter text in a text box by the input text and index
         * 
         * @param index
         *            the index of the text box on the screen
         * @param text
         *            the text to enter
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse EnterText(int index, String text);

        /**
         * will click on button with the input index
         * 
         * @param line
         *            the index of the button on the screen
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse ClickOnButton(int line);

        /**
         * will clear a text box with the input index
         * 
         * @param index
         *            the index of the text box to clear
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse ClearEditText(int index);

        /**
         * will click on button that includes the input text
         * 
         * @param text
         *            the text on the button
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse ClickOnButtonWithText(String text);

        /**
         * will click on the text with the input text
         * 
         * @param text
         *            the text to click on
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse ClickOnText(String text);

        /**
         * simulate a click on an hardware button
         * 
         * @param button
         *            an enum of the possible hardware buttons
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse ClickOnHardwareButton(robotium_client.Enums.HardwareButtons button);

        /**
         * will click on the single input char
         * 
         * @param key
         *            ascii number of the char wanted to click
         * @return return status of the operation
         * @throws Exception
         */
        CommandResponse SendKey(int key);

        /**
         * will close the connection to the server
         * 
         * @throws Exception
         */
        void CloseConnection();

        CommandResponse GetViews();

        CommandResponse SwipeLeft();

        CommandResponse SwipeRight();

        CommandResponse ClickOnImageButton(int index);

        CommandResponse ClickOnImage(int index);

        CommandResponse ScrollDown();

        CommandResponse IsTextVisible(String text);

        CommandResponse ScrollDownUntilTextIsVisible(String text);

        CommandResponse GetCurrentActivity();

        CommandResponse ClickOnActionBarItem(int index);

        CommandResponse ClickOnScreen(float x, float y, bool relative);

        CommandResponse Drag(float fromX, float toX, float fromY, float toY, int steps, bool relative);

        CommandResponse SetOrientation(int orientation);

        CommandResponse ScrollToEdge(robotium_client.Enums.EDGE edge);

        CommandResponse VerifyViewExistsByDescription(String description, bool click, bool startsWith,
              bool clickInSpecificPosition, float x, float y);

        CommandResponse ClickInList(int index1, int index2);

        CommandResponse ClickInList(int index);

        CommandResponse Click(String expression);

        CommandResponse GetAllVisibleIds();

        CommandResponse WaitForActivity(String activity, int timeout);

        CommandResponse ClickOnWebElement(String by, String expression);

        CommandResponse EnterTextInWebElement(String by, String expression, String text);

        string TakeScreenshot();

    }
}
