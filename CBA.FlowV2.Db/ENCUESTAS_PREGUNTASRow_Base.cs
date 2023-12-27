// <fileinfo name="ENCUESTAS_PREGUNTASRow_Base.cs">
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
	/// The base class for <see cref="ENCUESTAS_PREGUNTASRow"/> that 
	/// represents a record in the <c>ENCUESTAS_PREGUNTAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ENCUESTAS_PREGUNTASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ENCUESTAS_PREGUNTASRow_Base
	{
		private decimal _id;
		private decimal _encuesta_id;
		private decimal _tipos_item_encuesta_id;
		private string _titulo;
		private string _descripcion;
		private decimal _orden;

		/// <summary>
		/// Initializes a new instance of the <see cref="ENCUESTAS_PREGUNTASRow_Base"/> class.
		/// </summary>
		public ENCUESTAS_PREGUNTASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ENCUESTAS_PREGUNTASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ENCUESTA_ID != original.ENCUESTA_ID) return true;
			if (this.TIPOS_ITEM_ENCUESTA_ID != original.TIPOS_ITEM_ENCUESTA_ID) return true;
			if (this.TITULO != original.TITULO) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.ORDEN != original.ORDEN) return true;
			
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
		/// Gets or sets the <c>ENCUESTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>ENCUESTA_ID</c> column value.</value>
		public decimal ENCUESTA_ID
		{
			get { return _encuesta_id; }
			set { _encuesta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPOS_ITEM_ENCUESTA_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPOS_ITEM_ENCUESTA_ID</c> column value.</value>
		public decimal TIPOS_ITEM_ENCUESTA_ID
		{
			get { return _tipos_item_encuesta_id; }
			set { _tipos_item_encuesta_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TITULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TITULO</c> column value.</value>
		public string TITULO
		{
			get { return _titulo; }
			set { _titulo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION</c> column value.</value>
		public string DESCRIPCION
		{
			get { return _descripcion; }
			set { _descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ORDEN</c> column value.
		/// </summary>
		/// <value>The <c>ORDEN</c> column value.</value>
		public decimal ORDEN
		{
			get { return _orden; }
			set { _orden = value; }
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
			dynStr.Append("@CBA@ENCUESTA_ID=");
			dynStr.Append(ENCUESTA_ID);
			dynStr.Append("@CBA@TIPOS_ITEM_ENCUESTA_ID=");
			dynStr.Append(TIPOS_ITEM_ENCUESTA_ID);
			dynStr.Append("@CBA@TITULO=");
			dynStr.Append(TITULO);
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			return dynStr.ToString();
		}
	} // End of ENCUESTAS_PREGUNTASRow_Base class
} // End of namespace
