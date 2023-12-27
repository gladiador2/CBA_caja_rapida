// <fileinfo name="OBJETIVOS_PROMOTORAS_INFO_COMPRow_Base.cs">
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
	/// The base class for <see cref="OBJETIVOS_PROMOTORAS_INFO_COMPRow"/> that 
	/// represents a record in the <c>OBJETIVOS_PROMOTORAS_INFO_COMP</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="OBJETIVOS_PROMOTORAS_INFO_COMPRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class OBJETIVOS_PROMOTORAS_INFO_COMPRow_Base
	{
		private decimal _funcionario_id;
		private decimal _anho;
		private decimal _monto_objetivo;
		private bool _monto_objetivoNull = true;
		private decimal _monto_tope;
		private bool _monto_topeNull = true;
		private decimal _moneda_id;
		private bool _moneda_idNull = true;
		private decimal _porcentaje_comision;
		private bool _porcentaje_comisionNull = true;
		private decimal _porcentaje_tope;
		private bool _porcentaje_topeNull = true;
		private decimal _persona_id;
		private string _funcionario_nombre;
		private string _persona_nombre;

		/// <summary>
		/// Initializes a new instance of the <see cref="OBJETIVOS_PROMOTORAS_INFO_COMPRow_Base"/> class.
		/// </summary>
		public OBJETIVOS_PROMOTORAS_INFO_COMPRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(OBJETIVOS_PROMOTORAS_INFO_COMPRow_Base original)
		{
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.ANHO != original.ANHO) return true;
			if (this.IsMONTO_OBJETIVONull != original.IsMONTO_OBJETIVONull) return true;
			if (!this.IsMONTO_OBJETIVONull && !original.IsMONTO_OBJETIVONull)
				if (this.MONTO_OBJETIVO != original.MONTO_OBJETIVO) return true;
			if (this.IsMONTO_TOPENull != original.IsMONTO_TOPENull) return true;
			if (!this.IsMONTO_TOPENull && !original.IsMONTO_TOPENull)
				if (this.MONTO_TOPE != original.MONTO_TOPE) return true;
			if (this.IsMONEDA_IDNull != original.IsMONEDA_IDNull) return true;
			if (!this.IsMONEDA_IDNull && !original.IsMONEDA_IDNull)
				if (this.MONEDA_ID != original.MONEDA_ID) return true;
			if (this.IsPORCENTAJE_COMISIONNull != original.IsPORCENTAJE_COMISIONNull) return true;
			if (!this.IsPORCENTAJE_COMISIONNull && !original.IsPORCENTAJE_COMISIONNull)
				if (this.PORCENTAJE_COMISION != original.PORCENTAJE_COMISION) return true;
			if (this.IsPORCENTAJE_TOPENull != original.IsPORCENTAJE_TOPENull) return true;
			if (!this.IsPORCENTAJE_TOPENull && !original.IsPORCENTAJE_TOPENull)
				if (this.PORCENTAJE_TOPE != original.PORCENTAJE_TOPE) return true;
			if (this.PERSONA_ID != original.PERSONA_ID) return true;
			if (this.FUNCIONARIO_NOMBRE != original.FUNCIONARIO_NOMBRE) return true;
			if (this.PERSONA_NOMBRE != original.PERSONA_NOMBRE) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get { return _funcionario_id; }
			set { _funcionario_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO</c> column value.
		/// </summary>
		/// <value>The <c>ANHO</c> column value.</value>
		public decimal ANHO
		{
			get { return _anho; }
			set { _anho = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_OBJETIVO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_OBJETIVO</c> column value.</value>
		public decimal MONTO_OBJETIVO
		{
			get
			{
				if(IsMONTO_OBJETIVONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_objetivo;
			}
			set
			{
				_monto_objetivoNull = false;
				_monto_objetivo = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_OBJETIVO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_OBJETIVONull
		{
			get { return _monto_objetivoNull; }
			set { _monto_objetivoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO_TOPE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO_TOPE</c> column value.</value>
		public decimal MONTO_TOPE
		{
			get
			{
				if(IsMONTO_TOPENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto_tope;
			}
			set
			{
				_monto_topeNull = false;
				_monto_tope = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO_TOPE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTO_TOPENull
		{
			get { return _monto_topeNull; }
			set { _monto_topeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONEDA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONEDA_ID</c> column value.</value>
		public decimal MONEDA_ID
		{
			get
			{
				if(IsMONEDA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _moneda_id;
			}
			set
			{
				_moneda_idNull = false;
				_moneda_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONEDA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONEDA_IDNull
		{
			get { return _moneda_idNull; }
			set { _moneda_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_COMISION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_COMISION</c> column value.</value>
		public decimal PORCENTAJE_COMISION
		{
			get
			{
				if(IsPORCENTAJE_COMISIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_comision;
			}
			set
			{
				_porcentaje_comisionNull = false;
				_porcentaje_comision = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_COMISION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_COMISIONNull
		{
			get { return _porcentaje_comisionNull; }
			set { _porcentaje_comisionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_TOPE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_TOPE</c> column value.</value>
		public decimal PORCENTAJE_TOPE
		{
			get
			{
				if(IsPORCENTAJE_TOPENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_tope;
			}
			set
			{
				_porcentaje_topeNull = false;
				_porcentaje_tope = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_TOPE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_TOPENull
		{
			get { return _porcentaje_topeNull; }
			set { _porcentaje_topeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_ID</c> column value.
		/// </summary>
		/// <value>The <c>PERSONA_ID</c> column value.</value>
		public decimal PERSONA_ID
		{
			get { return _persona_id; }
			set { _persona_id = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FUNCIONARIO_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_NOMBRE</c> column value.</value>
		public string FUNCIONARIO_NOMBRE
		{
			get { return _funcionario_nombre; }
			set { _funcionario_nombre = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PERSONA_NOMBRE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PERSONA_NOMBRE</c> column value.</value>
		public string PERSONA_NOMBRE
		{
			get { return _persona_nombre; }
			set { _persona_nombre = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@ANHO=");
			dynStr.Append(ANHO);
			dynStr.Append("@CBA@MONTO_OBJETIVO=");
			dynStr.Append(IsMONTO_OBJETIVONull ? (object)"<NULL>" : MONTO_OBJETIVO);
			dynStr.Append("@CBA@MONTO_TOPE=");
			dynStr.Append(IsMONTO_TOPENull ? (object)"<NULL>" : MONTO_TOPE);
			dynStr.Append("@CBA@MONEDA_ID=");
			dynStr.Append(IsMONEDA_IDNull ? (object)"<NULL>" : MONEDA_ID);
			dynStr.Append("@CBA@PORCENTAJE_COMISION=");
			dynStr.Append(IsPORCENTAJE_COMISIONNull ? (object)"<NULL>" : PORCENTAJE_COMISION);
			dynStr.Append("@CBA@PORCENTAJE_TOPE=");
			dynStr.Append(IsPORCENTAJE_TOPENull ? (object)"<NULL>" : PORCENTAJE_TOPE);
			dynStr.Append("@CBA@PERSONA_ID=");
			dynStr.Append(PERSONA_ID);
			dynStr.Append("@CBA@FUNCIONARIO_NOMBRE=");
			dynStr.Append(FUNCIONARIO_NOMBRE);
			dynStr.Append("@CBA@PERSONA_NOMBRE=");
			dynStr.Append(PERSONA_NOMBRE);
			return dynStr.ToString();
		}
	} // End of OBJETIVOS_PROMOTORAS_INFO_COMPRow_Base class
} // End of namespace
