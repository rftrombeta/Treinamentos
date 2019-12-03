package br.trombeta.servicos;

import java.util.Calendar;

import br.trombeta.entidades.Filme;
import br.trombeta.entidades.NotaAluguel;
import br.trombeta.utils.DateUtils;

public class AluguelService {
	public NotaAluguel alugar(Filme filme) {
		
		if(filme.getEstoque() == 0)
			throw new RuntimeException("Filme sem estoque");
		
		NotaAluguel nota = new NotaAluguel();
		nota.setPreco(filme.getAluguel());
		nota.setDataEntrega(DateUtils.obterDataDiferencaDias(1));
		filme.setEstoque(filme.getEstoque() - 1);
		return nota;
		
	}
}
