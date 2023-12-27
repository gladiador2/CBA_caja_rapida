// <fileinfo name="TRAMITES_TIPOS_CAMPOS_ETAPASRow_Base.cs">
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
	/// The base class for <see cref="TRAMITES_TIPOS_CAMPOS_ETAPASRow"/> that 
	/// represents a record in the <c>TRAMITES_TIPOS_CAMPOS_ETAPAS</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TRAMITES_TIPOS_CAMPOS_ETAPASRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TRAMITES_TIPOS_CAMPOS_ETAPASRow_Base
	{
		private decimal _id;
		private string _nombre;
		private decimal _tipo_de_dato_id;
		private decimal _orden;
		private decimal _tramite_tipo_etapa_id;
		private bool _tramite_tipo_etapa_idNull = true;
		private string _genera_alarma;
		private decimal _tramite_tipo_id;
		private bool _tramite_tipo_idNull = true;
		private string _es_obligatorio;
		private decimal _tipo_texto_predefinido_id;
		private bool _tipo_texto_predefinido_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TRAMITES_TIPOS_CAMPOS_ETAPASRow_Base"/> class.
		/// </summary>
		public TRAMITES_TIPOS_CAMPOS_ETAPASRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TRAMITES_TIPOS_CAMPOS_ETAPASRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.TIPO_DE_DATO_ID != original.TIPO_DE_DATO_ID) return true;
			if (this.ORDEN != original.ORDEN) return true;
			if (this.IsTRAMITE_TIPO_ETAPA_IDNull != original.IsTRAMITE_TIPO_ETAPA_IDNull) return true;
			if (!this.IsTRAMITE_TIPO_ETAPA_IDNull && !original.IsTRAMITE_TIPO_ETAPA_IDNull)
				if (this.TRAMITE_TIPO_ETAPA_ID != original.TRAMITE_TIPO_ETAPA_ID) return true;
			if (this.GENERA_ALARMA != original.GENERA_ALARMA) return true;
			if (this.IsTRAMITE_TIPO_IDNull != original.IsTRAMITE_TIPO_IDNull) return true;
			if (!this.IsTRAMITE_TIPO_IDNull && !original.IsTRAMITE_TIPO_IDNull)
				if (this.TRAMITE_TIPO_ID != original.TRAMITE_TIPO_ID) return true;
			if (this.ES_OBLIGATORIO != original.ES_OBLIGATORIO) return true;
			if (this.IsTIPO_TEXTO_PREDEFINIDO_IDNull != original.IsTIPO_TEXTO_PREDEFINIDO_IDNull) return true;
			if (!this.IsTIPO_TEXTO_PREDEFINIDO_IDNull && !original.IsTIPO_TEXTO_PREDEFINIDO_IDNull)
				if (this.TIPO_TEXTO_PREDEFINIDO_ID != original.TIPO_TEXTO_PREDEFINIDO_ID) return true;
			
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
		/// Gets or sets the <c>NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE</c> column value.</value>
		public string NOMBRE
		{
			get { return _nombre; }
			set { _nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_DE_DATO_ID</c> column value.
		/// </summary>
		/// <value>The <c>TIPO_DE_DATO_ID</c> column value.</value>
		public decimal TIPO_DE_DATO_ID
		{
			get { return _tipo_de_dato_id; }
			set { _tipo_de_dato_id = value; }
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
		/// Gets or sets the <c>TRAMITE_TIPO_ETAPA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ETAPA_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ETAPA_ID
		{
			get
			{
				if(IsTRAMITE_TIPO_ETAPA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramite_tipo_etapa_id;
			}
			set
			{
				_tramite_tipo_etapa_idNull = false;
				_tramite_tipo_etapa_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITE_TIPO_ETAPA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITE_TIPO_ETAPA_IDNull
		{
			get { return _tramite_tipo_etapa_idNull; }
			set { _tramite_tipo_etapa_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GENERA_ALARMA</c> column value.
		/// </summary>
		/// <value>The <c>GENERA_ALARMA</c> column value.</value>
		public string GENERA_ALARMA
		{
			get { return _genera_alarma; }
			set { _genera_alarma = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TRAMITE_TIPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TRAMITE_TIPO_ID</c> column value.</value>
		public decimal TRAMITE_TIPO_ID
		{
			get
			{
				if(IsTRAMITE_TIPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tramite_tipo_id;
			}
			set
			{
				_tramite_tipo_idNull = false;
				_tramite_tipo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TRAMITE_TIPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTRAMITE_TIPO_IDNull
		{
			get { return _tramite_tipo_idNull; }
			set { _tramite_tipo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ES_OBLIGATORIO</c> column value.
		/// </summary>
		/// <value>The <c>ES_OBLIGATORIO</c> column value.</value>
		public string ES_OBLIGATORIO
		{
			get { return _es_obligatorio; }
			set { _es_obligatorio = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_TEXTO_PREDEFINIDO_ID</c> column value.</value>
		public decimal TIPO_TEXTO_PREDEFINIDO_ID
		{
			get
			{
				if(IsTIPO_TEXTO_PREDEFINIDO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_texto_predefinido_id;
			}
			set
			{
				_tipo_texto_predefinido_idNull = false;
				_tipo_texto_predefinido_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_TEXTO_PREDEFINIDO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_TEXTO_PREDEFINIDO_IDNull
		{
			get { return _tipo_texto_predefinido_idNull; }
			set { _tipo_texto_predefinido_idNull = value; }
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
			dynStr.Append("@CBA@NOMBRE=");
			dynStr.Append(NOMBRE);
			dynStr.Append("@CBA@TIPO_DE_DATO_ID=");
			dynStr.Append(TIPO_DE_DATO_ID);
			dynStr.Append("@CBA@ORDEN=");
			dynStr.Append(ORDEN);
			dynStr.Append("@CBA@TRAMITE_TIPO_ETAPA_ID=");
			dynStr.Append(IsTRAMITE_TIPO_ETAPA_IDNull ? (object)"<NULL>" : TRAMITE_TIPO_ETAPA_ID);
			dynStr.Append("@CBA@GENERA_ALARMA=");
			dynStr.Append(GENERA_ALARMA);
			dynStr.Append("@CBA@TRAMITE_TIPO_ID=");
			dynStr.Append(IsTRAMITE_TIPO_IDNull ? (object)"<NULL>" : TRAMITE_TIPO_ID);
			dynStr.Append("@CBA@ES_OBLIGATORIO=");
			dynStr.Append(ES_OBLIGATORIO);
			dynStr.Append("@CBA@TIPO_TEXTO_PREDEFINIDO_ID=");
			dynStr.Append(IsTIPO_TEXTO_PREDEFINIDO_IDNull ? (object)"<NULL>" : TIPO_TEXTO_PREDEFINIDO_ID);
			return dynStr.ToString();
		}
	} // End of TRAMITES_TIPOS_CAMPOS_ETAPASRow_Base class
} // End of namespace
