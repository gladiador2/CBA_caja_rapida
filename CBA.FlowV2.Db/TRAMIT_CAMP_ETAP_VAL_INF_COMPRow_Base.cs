// <fileinfo name="TRAMIT_CAMP_ETAP_VAL_INF_COMPRow_Base.cs">
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
	/// The base class for <see cref="TRAMIT_CAMP_ETAP_VAL_INF_COMPRow"/> that 
	/// represents a record in the <c>TRAMIT_CAMP_ETAP_VAL_INF_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMIT_CAMP_ETAP_VAL_INF_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMIT_CAMP_ETAP_VAL_INF_COMPRow_Base
	{
		private decimal _id;
		private decimal _tramite_campos_etapas_id;
		private string _tramite_campos_etapas_nombre;
		private decimal _tramite_tipo_id;
		private string _tramite_tipo_nombre;
		private string _valor_texto;
		private decimal _valor_numero;
		private bool _valor_numeroNull = true;
		private System.DateTime _valor_fecha;
		private bool _valor_fechaNull = true;
		private decimal _tramite_id;
		private string _tramite_titulo;
		private string _tramite_observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMIT_CAMP_ETAP_VAL_INF_COMPRow_Base"/> class.
		/// </summary>
		public TRAMIT_CAMP_ETAP_VAL_INF_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMIT_CAMP_ETAP_VAL_INF_COMPRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.TRAMITE_CAMPOS_ETAPAS_ID != original.TRAMITE_CAMPOS_ETAPAS_ID) return true;
			if (this.TRAMITE_CAMPOS_ETAPAS_NOMBRE != original.TRAMITE_CAMPOS_ETAPAS_NOMBRE) return true;
			if (this.TRAMITE_TIPO_ID != original.TRAMITE_TIPO_ID) return true;
			if (this.TRAMITE_TIPO_NOMBRE != original.TRAMITE_TIPO_NOMBRE) return true;
			if (this.VALOR_TEXTO != original.VALOR_TEXTO) return true;
			if (this.IsVALOR_NUMERONull != original.IsVALOR_NUMERONull) return true;
			if (!this.IsVALOR_NUMERONull && !original.IsVALOR_NUMERONull)
				if (this.VALOR_NUMERO != original.VALOR_NUMERO) return true;
			if (this.IsVALOR_FECHANull != original.IsVALOR_FECHANull) return true;
			if (!this.IsVALOR_FECHANull && !original.IsVALOR_FECHANull)
				if (this.VALOR_FECHA != original.VALOR_FECHA) return true;
			if (this.TRAMITE_ID != original.TRAMITE_ID) return true;
			if (this.TRAMITE_TITULO != original.TRAMITE_TITULO) return true;
			if (this.TRAMITE_OBSERVACION != original.TRAMITE_OBSERVACION) return true;
			
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
		/// Gets or sets the <c>TRAMITE_CAMPOS_ETAPAS_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_CAMPOS_ETAPAS_ID</c> column value.</value>
		public decimal TRAMITE_CAMPOS_ETAPAS_ID
		{
			get { return _tramite_campos_etapas_id; }
			set { _tramite_campos_etapas_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_CAMPOS_ETAPAS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_CAMPOS_ETAPAS_NOMBRE</c> column value.</value>
		public string TRAMITE_CAMPOS_ETAPAS_NOMBRE
		{
			get { return _tramite_campos_etapas_nombre; }
			set { _tramite_campos_etapas_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ID
		{
			get { return _tramite_tipo_id; }
			set { _tramite_tipo_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_NOMBRE</c> column value.</value>
		public string TRAMITE_TIPO_NOMBRE
		{
			get { return _tramite_tipo_nombre; }
			set { _tramite_tipo_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_TEXTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_TEXTO</c> column value.</value>
		public string VALOR_TEXTO
		{
			get { return _valor_texto; }
			set { _valor_texto = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_NUMERO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_NUMERO</c> column value.</value>
		public decimal VALOR_NUMERO
		{
			get
			{
				if(IsVALOR_NUMERONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_numero;
			}
			set
			{
				_valor_numeroNull = false;
				_valor_numero = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_NUMERO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_NUMERONull
		{
			get { return _valor_numeroNull; }
			set { _valor_numeroNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>VALOR_FECHA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>VALOR_FECHA</c> column value.</value>
		public System.DateTime VALOR_FECHA
		{
			get
			{
				if(IsVALOR_FECHANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _valor_fecha;
			}
			set
			{
				_valor_fechaNull = false;
				_valor_fecha = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="VALOR_FECHA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsVALOR_FECHANull
		{
			get { return _valor_fechaNull; }
			set { _valor_fechaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_ID</c> column value.
		/// </summary>
		/// <value>The <c>TRAMITE_ID</c> column value.</value>
		public decimal TRAMITE_ID
		{
			get { return _tramite_id; }
			set { _tramite_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TITULO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TITULO</c> column value.</value>
		public string TRAMITE_TITULO
		{
			get { return _tramite_titulo; }
			set { _tramite_titulo = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_OBSERVACION</c> column value.</value>
		public string TRAMITE_OBSERVACION
		{
			get { return _tramite_observacion; }
			set { _tramite_observacion = value; }
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
			dynStr.Append("@CBA@TRAMITE_CAMPOS_ETAPAS_ID=");
			dynStr.Append(TRAMITE_CAMPOS_ETAPAS_ID);
			dynStr.Append("@CBA@TRAMITE_CAMPOS_ETAPAS_NOMBRE=");
			dynStr.Append(TRAMITE_CAMPOS_ETAPAS_NOMBRE);
			dynStr.Append("@CBA@TRAMITE_TIPO_ID=");
			dynStr.Append(TRAMITE_TIPO_ID);
			dynStr.Append("@CBA@TRAMITE_TIPO_NOMBRE=");
			dynStr.Append(TRAMITE_TIPO_NOMBRE);
			dynStr.Append("@CBA@VALOR_TEXTO=");
			dynStr.Append(VALOR_TEXTO);
			dynStr.Append("@CBA@VALOR_NUMERO=");
			dynStr.Append(IsVALOR_NUMERONull ? (object)"<NULL>" : VALOR_NUMERO);
			dynStr.Append("@CBA@VALOR_FECHA=");
			dynStr.Append(IsVALOR_FECHANull ? (object)"<NULL>" : VALOR_FECHA);
			dynStr.Append("@CBA@TRAMITE_ID=");
			dynStr.Append(TRAMITE_ID);
			dynStr.Append("@CBA@TRAMITE_TITULO=");
			dynStr.Append(TRAMITE_TITULO);
			dynStr.Append("@CBA@TRAMITE_OBSERVACION=");
			dynStr.Append(TRAMITE_OBSERVACION);
			return dynStr.ToString();
		}
	} // End of TRAMIT_CAMP_ETAP_VAL_INF_COMPRow_Base class
} // End of namespace
