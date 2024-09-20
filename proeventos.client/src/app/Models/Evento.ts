import { Lote } from "./Lote";
import { RedesSociais } from "./RedeSocial";
import { PalestrantesEventos } from "./Palestrante";

export interface Evento {

  id: number;
  local?: string;
  dataEvento?: Date;
  tema?: string;
  qtdPessoas: number;
  imagemURL?: string;
  telefone?: string;
  email?: string;
  lotes: Lote[];
  redesSociais: RedesSociais[];
  palestranteEventos: PalestrantesEventos[];
}

