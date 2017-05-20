﻿using System;
using System.Data;
using System.Collections.Generic;

namespace DotCEP.Localidades
{
	public class Municipio
	{
		#region Propriedades

		public int CodigoEstado { get; private set; }

		public int Codigo { get; private set; }

		public string Nome { get; private set; }

		#endregion

<<<<<<< HEAD
		#region Lista
=======
>>>>>>> master
		public static List<Municipio> ObterListaDeMunicipio()
		{
			List<Municipio> listaDeMunicipios = new List<Municipio>();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.* from Municipios t";
			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}
<<<<<<< HEAD

		public static List<Municipio> ObterListaDeMunicipio(UF SiglaEstado)
		{
			List<Municipio> listaDeMunicipios = new List<Municipio>();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.* from Municipios t where t.CodigoEstado = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", Convert.ToInt16(SiglaEstado).ToString());

			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		/// <summary>
		/// Retorna a lista de municípios.
		/// </summary>
		/// <returns>The lista de municipio.</returns>
		/// <param name="Estado">Nome ou sigla do estado</param>
		public static List<Municipio> ObterListaDeMunicipio(string estado)
		{
			List<Municipio> listaDeMunicipios = new List<Municipio>();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select m.* from Municipios m  " +
			"inner join Estados e " +
			"on e.codigo = m.codigoestado " +
			"where e.sigla = #sigla#";

			//Se for passado o nome do estado, ele pega a sigla do mesmo.
			if (estado.Length != 2)
			{
				estado = Localidades.Estado.ObterSiglaDoEstado(estado);
			}

			cmd.AddParameter("sigla", Spartacus.Database.Type.STRING);

			cmd.SetValue("sigla", estado);

			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		public static string ObterNomeDoMunicipio(uint CodigoMunicipio)
		{
			String saida = String.Empty;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabelaResultado;

			cmd.v_text = "select t.nome from Municipios t where t.codigo = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", CodigoMunicipio.ToString());

			tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				saida = tabelaResultado.Rows[0]["nome"].ToString();
			}

			return saida;
		}
		#endregion

		#region Codigo
		public static int ObterCodigoDoMunicipio(string NomeMunicipio, UF SiglaEstado)
		{
			int saida = 0;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabelaResultado;

			cmd.v_text = "select t.Codigo from Municipios t where t.nome = #nome# and t.CodigoEstado = #estado#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("estado", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", Convert.ToInt32(SiglaEstado).ToString());

			tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				saida = Convert.ToInt32(tabelaResultado.Rows[0]["Codigo"].ToString());
			}

			return saida;
		}

		/// <summary>
		/// Obtem o codigo do municipio.
		/// </summary>
		/// <returns>O codigo do municipio.</returns>
		/// <param name="NomeMunicipio">Nome do municipio</param>
		/// <param name="estado">Nome ou sigla do estado</param>
		public static int ObterCodigoDoMunicipio(string NomeMunicipio, string estado)
		{
			int saida = 0;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabelaResultado;

			cmd.v_text = "select t.Codigo from Municipios t where t.nome = #nome# and t.CodigoEstado = #estado#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("estado", Spartacus.Database.Type.INTEGER);

			estado = Estado.ObterCodigoDoEstado(estado);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", estado);

			tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

=======

		public static List<Municipio> ObterListaDeMunicipio(UF SiglaEstado)
		{
			List<Municipio> listaDeMunicipios = new List<Municipio>();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select t.* from Municipios t where t.CodigoEstado = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", Convert.ToInt16(SiglaEstado).ToString());

			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		public static List<Municipio> ObterListaDeMunicipio(string SiglaEstado)
		{
			List<Municipio> listaDeMunicipios = new List<Municipio>();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "select m.* from Municipios m  " +
			"inner join Estados e " +
			"on e.codigo = m.codigoestado" +
			"  where e.sigla = #sigla#";


			cmd.AddParameter("sigla", Spartacus.Database.Type.STRING);

			cmd.SetValue("sigla", SiglaEstado);

			listaDeMunicipios = ObterListaDoBanco(cmd.GetUpdatedText());

			return listaDeMunicipios;
		}

		public static string ObterNomeDoMunicipio(uint CodigoMunicipio)
		{
			String saida = String.Empty;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabelaResultado;

			cmd.v_text = "select t.nome from Municipios t where t.codigo = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", CodigoMunicipio.ToString());

			tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

			if (tabelaResultado.Rows.Count != 0)
			{
				saida = tabelaResultado.Rows[0]["nome"].ToString();
			}

			return saida;
		}

		public static int ObterCodigoDoMunicipio(string NomeMunicipio, UF SiglaEstado)
		{
			int saida = 0;
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();
			DataTable tabelaResultado;

			cmd.v_text = "select t.Codigo from Municipios t where t.nome = #nome# and t.CodigoEstado = #estado#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("estado", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("estado", Convert.ToInt16(DotCEP.UF.RS).ToString());

			tabelaResultado = ObterTabelaDoBanco(cmd.GetUpdatedText());

>>>>>>> master
			if (tabelaResultado.Rows.Count != 0)
			{
				saida = Convert.ToInt32(tabelaResultado.Rows[0]["Codigo"].ToString());
			}
<<<<<<< HEAD

			return saida;
		}

		#endregion

		#region Informaçoes
		public static Municipio ObterInformacoesDoMunicipio(string NomeMunicipio, UF SiglaEstado)
		{
			Municipio municipioBase = new Municipio();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select * from Municipios m where m.nome = #nome# and m.codigoestado = #codigo#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("codigo", Convert.ToInt32(SiglaEstado).ToString());

			//E retornado apenas o primeiro valor da lista caso ele tenha mais de um.
			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		/// <summary>
		/// Obtem informacoes do municipio.
		/// </summary>
		/// <returns>The informacoes do municipio.</returns>
		/// <param name="NomeMunicipio">Nome municipio.</param>
		/// <param name="estado">Nome ou sigla do estado</param>
		public static Municipio ObterInformacoesDoMunicipio(string NomeMunicipio, string estado)
		{
			Municipio municipioBase = new Municipio();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select * from Municipios m where m.nome = #nome# and m.codigoestado = #codigo#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);

			estado = Estado.ObterCodigoDoEstado(estado);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("codigo", estado);

			//E retornado apenas o primeiro valor da lista caso ele tenha mais de um.
			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		public static Municipio ObterInformacoesDoMunicipio(uint CodigoMunicipio)
		{
			Municipio municipioBase = new Municipio();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select * from Municipios m where m.Codigo = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", CodigoMunicipio.ToString());

			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		#endregion

		private static DataTable ObterTabelaDoBanco(string p_Query)
		{
			DataTable tabelaSaida = new DataTable();
			Spartacus.Database.Generic database;
			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());
				tabelaSaida = database.Query(p_Query, "Resultado");
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return tabelaSaida;
		}

		private static List<Municipio> ObterListaDoBanco(string p_Query)
		{
			Spartacus.Database.Generic database;
			List<Municipio> ListaDeMunicipios = new List<Municipio>();

=======

			return saida;
		}

		public static Municipio ObterInformacoesDoMunicipio(string NomeMunicipio, UF SiglaEstado)
		{
			Municipio municipioBase = new Municipio();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select * from Municipios m where m.nome = #nome# and m.codigoestado = #codigo#";
			cmd.AddParameter("nome", Spartacus.Database.Type.STRING);
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);

			cmd.SetValue("nome", NomeMunicipio);
			cmd.SetValue("codigo", Convert.ToInt16(DotCEP.UF.RS).ToString());

			//E retornado apenas o primeiro valor da lista caso ele tenha mais de um.
			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		public static Municipio ObterInformacoesDoMunicipio(uint CodigoMunicipio)
		{
			Municipio municipioBase = new Municipio();
			Spartacus.Database.Command cmd = new Spartacus.Database.Command();

			cmd.v_text = "Select * from Municipios m where m.Codigo = #codigo#";
			cmd.AddParameter("codigo", Spartacus.Database.Type.INTEGER);
			cmd.SetValue("codigo", CodigoMunicipio.ToString());

			municipioBase = ObterListaDoBanco(cmd.GetUpdatedText())[0];

			return municipioBase;
		}

		private static DataTable ObterTabelaDoBanco(string p_Query)
		{
			DataTable tabelaSaida = new DataTable();
			Spartacus.Database.Generic database;
			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());
				tabelaSaida = database.Query(p_Query, "Resultado");
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return tabelaSaida;
		}

		private static List<Municipio> ObterListaDoBanco(string p_Query)
		{
			Spartacus.Database.Generic database;
			List<Municipio> ListaDeMunicipios = new List<Municipio>();

>>>>>>> master
			try
			{
				database = new Spartacus.Database.Sqlite(BancosDeDados.ObterCaminhoBancoLugares());

				ListaDeMunicipios = database.QueryList<Municipio>(p_Query);
			}
			catch (Spartacus.Database.Exception ex)
			{
				throw new Exception(ex.v_message);
			}

			return ListaDeMunicipios;
		}
	}
}
