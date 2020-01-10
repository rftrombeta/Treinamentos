package common;

import com.codeborne.selenide.Configuration;
import org.testng.annotations.BeforeMethod;
import pages.LoginPage;
import pages.MoviePage;
import pages.SideBar;

public class BaseTest {
    protected static LoginPage login;
    protected static SideBar sideBar;
    protected static MoviePage movie;

    @BeforeMethod
    public void setup() {
        Configuration.browser = "chrome";
        Configuration.baseUrl = "http://ninjaplus-web:5000";

        login = new LoginPage();
        sideBar = new SideBar();
        movie = new MoviePage();
    }
}
