package tests;

import common.BaseTest;
import org.testng.annotations.AfterMethod;
import org.testng.annotations.DataProvider;
import org.testng.annotations.Test;

import static com.codeborne.selenide.Condition.text;

public class LoginTests extends BaseTest {

    @DataProvider(name = "login-alerts")
    public Object[][] loginProvider() {
        return new Object[][]{
                {"rodstrombeta@gmail.com", "abc123", "Usu�rio e/ou senha inv�lidos"},
                {"fulano_de_tal@gmail.com", "pwd123", "Usu�rio e/ou senha inv�lidos"},
                {"", "pwd123", "Opps. Cad� o email?"},
                {"rodstrombeta@gmail.com", "", "Opps. Cad� a senha?"},
        };
    }

    @Test
    public void shouldSeeLoggedUser() {
        login
                .open()
                .with("rodstrombeta@gmail.com", "pwd123");

        sideBar.loggedUser().shouldHave(text("Rodrigo"));
    }

    @Test(dataProvider = "login-alerts")
    public void shouldSeeLoginAlerts(String email, String pass, String expectAlert) {
        login
                .open()
                .with(email, pass)
                .alert().shouldHave(text(expectAlert));
    }

    @AfterMethod
    public void cleanUp() {
        login.clearSession();
    }
}
