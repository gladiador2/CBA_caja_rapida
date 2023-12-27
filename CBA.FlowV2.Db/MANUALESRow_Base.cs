// <fileinfo name="MANUALESRow_Base.cs">
//		<copyright>
//			All rights reserved.
//		</copyright>
//		<remarks>
//			Do not change this source code manually. Changes to this file may 
//			cause incorrect behavior and will be lost if the code is regenerated.
//		</remarks>
//		<generator rewritefile="True" infourl="http://www.SharpPower.com">RapTier</generator>
// </fileinfo>

using System;

namespace CBA.FlowV2.Db
{
	/// <summary>
	/// The base class for <see cref="MANUALESRow"/> that 
	/// represents a record in the <c>MANUALES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="MANUALESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class MANUALESRow_Base
	{
		private decimal _id;
		private decimal _entidad_id;
		private string _tabla_id;
		private string _identificador_texto;
		private string _nombre_archivo;
		private decimal _version;
		private string _youtube_id;
		private string _estado;
		private string _nombre_pantalla;
		private string _flags_latex;

		/// <summary>
		/// Initializes a new instance of the <see cref="MANUALESRow_Base"/> class.
		/// </summary>
		public MANUALESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(MANUALESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.TABLA_ID != original.TABLA_ID) return true;
			if (this.IDENTIFICADOR_TEXTO != original.IDENTIFICADOR_TEXTO) return true;
			if (this.NOMBRE_ARCHIVO != original.NOMBRE_ARCHIVO) return true;
			if (this.VERSION != original.VERSION) return true;
			if (this.YOUTUBE_ID != original.YOUTUBE_ID) return true;
			if (this.ESTADO != original.ESTADO) return true;
			if (this.NOMBRE_PANTALLA != original.NOMBRE_PANTALLA) return true;
			if (this.FLAGS_LATEX != original.FLAGS_LATEX) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ID</c> column value.
		/// </summary>
		/// <value>The <c>ID</c> column value.</value>
		public decimal ID
		{
			get { return _id; }
			set { _id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ENTIDAD_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_ID</c> column value.</value>
		public decimal ENTIDAD_ID
		{
			get { return _entidad_id; }
			set { _entidad_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TABLA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TABLA_ID</c> column value.</value>
		public string TABLA_ID
		{
			get { return _tabla_id; }
			set { _tabla_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>IDENTIFICADOR_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>IDENTIFICADOR_TEXTO</c> column value.</value>
		public string IDENTIFICADOR_TEXTO
		{
			get { return _identificador_texto; }
			set { _identificador_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_ARCHIVO</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_ARCHIVO</c> column value.</value>
		public string NOMBRE_ARCHIVO
		{
			get { return _nombre_archivo; }
			set { _nombre_archivo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VERSION</c> column value.
		/// </summary>
		/// <value>The <c>VERSION</c> column value.</value>
		public decimal VERSION
		{
			get { return _version; }
			set { _version = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>YOUTUBE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>YOUTUBE_ID</c> column value.</value>
		public string YOUTUBE_ID
		{
			get { return _youtube_id; }
			set { _youtube_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE_PANTALLA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE_PANTALLA</c> column value.</value>
		public string NOMBRE_PANTALLA
		{
			get { return _nombre_pantalla; }
			set { _nombre_pantalla = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FLAGS_LATEX</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FLAGS_LATEX</c> column value.</value>
		public string FLAGS_LATEX
		{
			get { return _flags_latex; }
			set { _flags_latex = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@TABLA_ID=");
			dynStr.Append(TABLA_ID);
			dynStr.Append("@CBA@IDENTIFICADOR_TEXTO=");
			dynStr.Append(IDENTIFICADOR_TEXTO);
			dynStr.Append("@CBA@NOMBRE_ARCHIVO=");
			dynStr.Append(NOMBRE_ARCHIVO);
			dynStr.Append("@CBA@VERSION=");
			dynStr.Append(VERSION);
			dynStr.Append("@CBA@YOUTUBE_ID=");
			dynStr.Append(YOUTUBE_ID);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			dynStr.Append("@CBA@NOMBRE_PANTALLA=");
			dynStr.Append(NOMBRE_PANTALLA);
			dynStr.Append("@CBA@FLAGS_LATEX=");
			dynStr.Append(FLAGS_LATEX);
			return dynStr.ToString();
		}
	} // End of MANUALESRow_Base class
} // End of namespace
