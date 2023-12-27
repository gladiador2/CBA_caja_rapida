// <fileinfo name="CTACTE_TARJETAS_TIPOSRow_Base.cs">
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
	/// The base class for <see cref="CTACTE_TARJETAS_TIPOSRow"/> that 
	/// represents a record in the <c>CTACTE_TARJETAS_TIPOS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTACTE_TARJETAS_TIPOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTACTE_TARJETAS_TIPOSRow_Base
	{
		private decimal _id;
		private string _codigo;
		private string _nombre;
		private decimal _procesadora_id;
		private bool _procesadora_idNull = true;
		private string _es_tarjeta_credito;
		private string _estado;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTACTE_TARJETAS_TIPOSRow_Base"/> class.
		/// </summary>
		public CTACTE_TARJETAS_TIPOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTACTE_TARJETAS_TIPOSRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.CODIGO != original.CODIGO) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.IsPROCESADORA_IDNull != original.IsPROCESADORA_IDNull) return true;
			if (!this.IsPROCESADORA_IDNull && !original.IsPROCESADORA_IDNull)
				if (this.PROCESADORA_ID != original.PROCESADORA_ID) return true;
			if (this.ES_TARJETA_CREDITO != original.ES_TARJETA_CREDITO) return true;
			if (this.ESTADO != original.ESTADO) return true;
			
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
		/// Gets or sets the <c>CODIGO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CODIGO</c> column value.</value>
		public string CODIGO
		{
			get { return _codigo; }
			set { _codigo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PROCESADORA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PROCESADORA_ID</c> column value.</value>
		public decimal PROCESADORA_ID
		{
			get
			{
				if(IsPROCESADORA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _procesadora_id;
			}
			set
			{
				_procesadora_idNull = false;
				_procesadora_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PROCESADORA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPROCESADORA_IDNull
		{
			get { return _procesadora_idNull; }
			set { _procesadora_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_TARJETA_CREDITO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ES_TARJETA_CREDITO</c> column value.</value>
		public string ES_TARJETA_CREDITO
		{
			get { return _es_tarjeta_credito; }
			set { _es_tarjeta_credito = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ESTADO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ESTADO</c> column value.</value>
		public string ESTADO
		{
			get { return _estado; }
			set { _estado = value; }
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
			dynStr.Append("@CBA@CODIGO=");
			dynStr.Append(CODIGO);
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@PROCESADORA_ID=");
			dynStr.Append(IsPROCESADORA_IDNull ? (object)"<NULL>" : PROCESADORA_ID);
			dynStr.Append("@CBA@ES_TARJETA_CREDITO=");
			dynStr.Append(ES_TARJETA_CREDITO);
			dynStr.Append("@CBA@ESTADO=");
			dynStr.Append(ESTADO);
			return dynStr.ToString();
		}
	} // End of CTACTE_TARJETAS_TIPOSRow_Base class
} // End of namespace
