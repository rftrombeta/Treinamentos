public class TestaCondicional {
	public static void main(String[] args) {
		System.out.println("TESTANDO CONDICIONAIS");
		System.out.println("");

		int idade = 16;
		int quantidadePessosa = 3;

		if (idade >= 18) {
			System.out.println("Voc� tem mais de 18 anos");
			System.out.println("seja bem vindo");
		}
		else {
			if (quantidadePessosa >= 2) {
				System.out.println("voc� n�o tem 18 anos, mas pode entrar, pois est� acompanhado");
			}
			else {
				System.out.println("infelizmente voc� n�o pode entrar");
			}
		}
	}
}