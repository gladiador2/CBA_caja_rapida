// <fileinfo name="COMENTARIOS_TRANSICIONESRow_Base.cs">
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
	/// The base class for <see cref="COMENTARIOS_TRANSICIONESRow"/> that 
	/// represents a record in the <c>COMENTARIOS_TRANSICIONES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="COMENTARIOS_TRANSICIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class COMENTARIOS_TRANSICIONESRow_Base
	{
		private decimal _id;
		private decimal _caso_id;
		private System.DateTime _fecha;
		private bool _fechaNull = true;
		private string _comentario;
		private decimal _operacion_id;
		private bool _operacion_idNull = true;
		private decimal _orden;
		private string _tipo;
		private decimal _comentario_texto_id;
		private bool _comentario_texto_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="COMENTARIOS_TRANSICIONESRow_Base"/> class.
		/// </summary>
		public COMENTARIOS_TRANSICIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(COMENTARIOS_TRANSICIONESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CASO_ID != original.CASO_ID) return true;
			if (this.IsFECHANull != original.IsFECHANull) return true;
			if (!this.IsFECHANull && !original.IsFECHANull)
				if (this.FECHA != original.FECHA) return true;
			if (this.COMENTARIO != original.COMENTARIO) return true;
			if (this.IsOPERACION_IDNull != original.IsOPERACION_IDNull) return true;
			if (!this.IsOPERACION_IDNull && !original.IsOPERACION_IDNull)
				if (this.OPERACION_ID != original.OPERACION_ID) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.TIPO != original.TIPO) return true;
			if (this.IsCOMENTARIO_TEXTO_IDNull != original.IsCOMENTARIO_TEXTO_IDNull) return true;
			if (!this.IsCOMENTARIO_TEXTO_IDNull && !original.IsCOMENTARIO_TEXTO_IDNull)
				if (this.COMENTARIO_TEXTO_ID != original.COMENTARIO_TEXTO_ID) return true;
			
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
		/// Gets or sets the <c>CASO_ID</c> column value.
		/// </summary>
		/// <value>The <c>CASO_ID</c> column value.</value>
		public decimal CASO_ID
		{
			get { return _caso_id; }
			set { _caso_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FECHA</c> column value.</value>
		public System.DateTime FECHA
		{
			get
			{
				if(IsFECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _fecha;
			}
			set
			{
				_fechaNull = false;
				_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFECHANull
		{
			get { return _fechaNull; }
			set { _fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMENTARIO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMENTARIO</c> column value.</value>
		public string COMENTARIO
		{
			get { return _comentario; }
			set { _comentario = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OPERACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OPERACION_ID</c> column value.</value>
		public decimal OPERACION_ID
		{
			get
			{
				if(IsOPERACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _operacion_id;
			}
			set
			{
				_operacion_idNull = false;
				_operacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="OPERACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsOPERACION_IDNull
		{
			get { return _operacion_idNull; }
			set { _operacion_idNull = value; }
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
		/// Gets or sets the <c>TIPO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO</c> column value.</value>
		public string TIPO
		{
			get { return _tipo; }
			set { _tipo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>COMENTARIO_TEXTO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>COMENTARIO_TEXTO_ID</c> column value.</value>
		public decimal COMENTARIO_TEXTO_ID
		{
			get
			{
				if(IsCOMENTARIO_TEXTO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _comentario_texto_id;
			}
			set
			{
				_comentario_texto_idNull = false;
				_comentario_texto_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="COMENTARIO_TEXTO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCOMENTARIO_TEXTO_IDNull
		{
			get { return _comentario_texto_idNull; }
			set { _comentario_texto_idNull = value; }
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
			dynStr.Append("@CBA@CASO_ID=");
			dynStr.Append(CASO_ID);
			dynStr.Append("@CBA@FECHA=");
			dynStr.Append(IsFECHANull ? (object)"<NULL>" : FECHA);
			dynStr.Append("@CBA@COMENTARIO=");
			dynStr.Append(COMENTARIO);
			dynStr.Append("@CBA@OPERACION_ID=");
			dynStr.Append(IsOPERACION_IDNull ? (object)"<NULL>" : OPERACION_ID);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@TIPO=");
			dynStr.Append(TIPO);
			dynStr.Append("@CBA@COMENTARIO_TEXTO_ID=");
			dynStr.Append(IsCOMENTARIO_TEXTO_IDNull ? (object)"<NULL>" : COMENTARIO_TEXTO_ID);
			return dynStr.ToString();
		}
	} // End of COMENTARIOS_TRANSICIONESRow_Base class
} // End of namespace
