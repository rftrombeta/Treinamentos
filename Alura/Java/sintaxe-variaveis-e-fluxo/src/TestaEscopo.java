public class TestaEscopo {
	public static void main(String[] args) {
		System.out.println("TESTANDO CONDICIONAIS 2");
		System.out.println("");

		int idade = 20;
		int quantidadePessoas = 3;
		boolean acompanhado;

		if(quantidadePessoas >= 2) {
			acompanhado = true;
		} else {
			acompanhado = false;
		}
		System.out.println("Valor de acompanhado = " + acompanhado);
		if (idade >= 18 && acompanhado) {
			System.out.println("seja bem vindo");
		}
		else {
			System.out.println("infelizmente voc� n�o pode entrar");
		}
	}
}