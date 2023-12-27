// <fileinfo name="CTB_INDICADORES_INFO_COMPLRow_Base.cs">
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
	/// The base class for <see cref="CTB_INDICADORES_INFO_COMPLRow"/> that 
	/// represents a record in the <c>CTB_INDICADORES_INFO_COMPL</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CTB_INDICADORES_INFO_COMPLRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CTB_INDICADORES_INFO_COMPLRow_Base
	{
		private decimal _id;
		private string _nombre;
		private string _descripcion;
		private decimal _limite_inferior_normal;
		private decimal _limite_superior_normal;
		private decimal _limite_inferior_multinacional;
		private bool _limite_inferior_multinacionalNull = true;
		private decimal _limite_superior_multinacional;
		private bool _limite_superior_multinacionalNull = true;
		private decimal _entidad_id;
		private string _entidad_nombre;
		private decimal _ctb_plan_cuentas;
		private string _ctb_plan_cuentas_nombre;
		private decimal _porcentaje_de_alarma;

		/// <summary>
		/// Initializes a new instance of the <see cref="CTB_INDICADORES_INFO_COMPLRow_Base"/> class.
		/// </summary>
		public CTB_INDICADORES_INFO_COMPLRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CTB_INDICADORES_INFO_COMPLRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.NOMBRE != original.NOMBRE) return true;
			if (this.DESCRIPCION != original.DESCRIPCION) return true;
			if (this.LIMITE_INFERIOR_NORMAL != original.LIMITE_INFERIOR_NORMAL) return true;
			if (this.LIMITE_SUPERIOR_NORMAL != original.LIMITE_SUPERIOR_NORMAL) return true;
			if (this.IsLIMITE_INFERIOR_MULTINACIONALNull != original.IsLIMITE_INFERIOR_MULTINACIONALNull) return true;
			if (!this.IsLIMITE_INFERIOR_MULTINACIONALNull && !original.IsLIMITE_INFERIOR_MULTINACIONALNull)
				if (this.LIMITE_INFERIOR_MULTINACIONAL != original.LIMITE_INFERIOR_MULTINACIONAL) return true;
			if (this.IsLIMITE_SUPERIOR_MULTINACIONALNull != original.IsLIMITE_SUPERIOR_MULTINACIONALNull) return true;
			if (!this.IsLIMITE_SUPERIOR_MULTINACIONALNull && !original.IsLIMITE_SUPERIOR_MULTINACIONALNull)
				if (this.LIMITE_SUPERIOR_MULTINACIONAL != original.LIMITE_SUPERIOR_MULTINACIONAL) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.ENTIDAD_NOMBRE != original.ENTIDAD_NOMBRE) return true;
			if (this.CTB_PLAN_CUENTAS != original.CTB_PLAN_CUENTAS) return true;
			if (this.CTB_PLAN_CUENTAS_NOMBRE != original.CTB_PLAN_CUENTAS_NOMBRE) return true;
			if (this.PORCENTAJE_DE_ALARMA != original.PORCENTAJE_DE_ALARMA) return true;
			
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
		/// Gets or sets the <c>LIMITE_INFERIOR_NORMAL</c> column value.
		/// </summary>
		/// <value>The <c>LIMITE_INFERIOR_NORMAL</c> column value.</value>
		public decimal LIMITE_INFERIOR_NORMAL
		{
			get { return _limite_inferior_normal; }
			set { _limite_inferior_normal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_SUPERIOR_NORMAL</c> column value.
		/// </summary>
		/// <value>The <c>LIMITE_SUPERIOR_NORMAL</c> column value.</value>
		public decimal LIMITE_SUPERIOR_NORMAL
		{
			get { return _limite_superior_normal; }
			set { _limite_superior_normal = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_INFERIOR_MULTINACIONAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIMITE_INFERIOR_MULTINACIONAL</c> column value.</value>
		public decimal LIMITE_INFERIOR_MULTINACIONAL
		{
			get
			{
				if(IsLIMITE_INFERIOR_MULTINACIONALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _limite_inferior_multinacional;
			}
			set
			{
				_limite_inferior_multinacionalNull = false;
				_limite_inferior_multinacional = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIMITE_INFERIOR_MULTINACIONAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIMITE_INFERIOR_MULTINACIONALNull
		{
			get { return _limite_inferior_multinacionalNull; }
			set { _limite_inferior_multinacionalNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIMITE_SUPERIOR_MULTINACIONAL</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIMITE_SUPERIOR_MULTINACIONAL</c> column value.</value>
		public decimal LIMITE_SUPERIOR_MULTINACIONAL
		{
			get
			{
				if(IsLIMITE_SUPERIOR_MULTINACIONALNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _limite_superior_multinacional;
			}
			set
			{
				_limite_superior_multinacionalNull = false;
				_limite_superior_multinacional = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIMITE_SUPERIOR_MULTINACIONAL"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIMITE_SUPERIOR_MULTINACIONALNull
		{
			get { return _limite_superior_multinacionalNull; }
			set { _limite_superior_multinacionalNull = value; }
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
		/// Gets or sets the <c>ENTIDAD_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>ENTIDAD_NOMBRE</c> column value.</value>
		public string ENTIDAD_NOMBRE
		{
			get { return _entidad_nombre; }
			set { _entidad_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTAS</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTAS</c> column value.</value>
		public decimal CTB_PLAN_CUENTAS
		{
			get { return _ctb_plan_cuentas; }
			set { _ctb_plan_cuentas = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CTB_PLAN_CUENTAS_NOMBRE</c> column value.
		/// </summary>
		/// <value>The <c>CTB_PLAN_CUENTAS_NOMBRE</c> column value.</value>
		public string CTB_PLAN_CUENTAS_NOMBRE
		{
			get { return _ctb_plan_cuentas_nombre; }
			set { _ctb_plan_cuentas_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_DE_ALARMA</c> column value.
		/// </summary>
		/// <value>The <c>PORCENTAJE_DE_ALARMA</c> column value.</value>
		public decimal PORCENTAJE_DE_ALARMA
		{
			get { return _porcentaje_de_alarma; }
			set { _porcentaje_de_alarma = value; }
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
			dynStr.Append("@CBA@DESCRIPCION=");
			dynStr.Append(DESCRIPCION);
			dynStr.Append("@CBA@LIMITE_INFERIOR_NORMAL=");
			dynStr.Append(LIMITE_INFERIOR_NORMAL);
			dynStr.Append("@CBA@LIMITE_SUPERIOR_NORMAL=");
			dynStr.Append(LIMITE_SUPERIOR_NORMAL);
			dynStr.Append("@CBA@LIMITE_INFERIOR_MULTINACIONAL=");
			dynStr.Append(IsLIMITE_INFERIOR_MULTINACIONALNull ? (object)"<NULL>" : LIMITE_INFERIOR_MULTINACIONAL);
			dynStr.Append("@CBA@LIMITE_SUPERIOR_MULTINACIONAL=");
			dynStr.Append(IsLIMITE_SUPERIOR_MULTINACIONALNull ? (object)"<NULL>" : LIMITE_SUPERIOR_MULTINACIONAL);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@ENTIDAD_NOMBRE=");
			dynStr.Append(ENTIDAD_NOMBRE);
			dynStr.Append("@CBA@CTB_PLAN_CUENTAS=");
			dynStr.Append(CTB_PLAN_CUENTAS);
			dynStr.Append("@CBA@CTB_PLAN_CUENTAS_NOMBRE=");
			dynStr.Append(CTB_PLAN_CUENTAS_NOMBRE);
			dynStr.Append("@CBA@PORCENTAJE_DE_ALARMA=");
			dynStr.Append(PORCENTAJE_DE_ALARMA);
			return dynStr.ToString();
		}
	} // End of CTB_INDICADORES_INFO_COMPLRow_Base class
} // End of namespace
