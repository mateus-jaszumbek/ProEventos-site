import { Evento } from "./Evento";
import { RedesSociais } from "./RedeSocial";

export interface PalestrantesEventos {
  id: number;
  nome?: string;
  miniCurriculo?: string;
  imagemURL?: string;
  telefone?: string;
  email?: string;
  redesSociais?: RedesSociais[];
  palestrantesEventos?: Evento[];
}
