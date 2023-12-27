// <fileinfo name="ESCALAS_COMISIONES_COBRADORESRow_Base.cs">
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
	/// The base class for <see cref="ESCALAS_COMISIONES_COBRADORESRow"/> that 
	/// represents a record in the <c>ESCALAS_COMISIONES_COBRADORES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ESCALAS_COMISIONES_COBRADORESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ESCALAS_COMISIONES_COBRADORESRow_Base
	{
		private decimal _id;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private decimal _anho;
		private bool _anhoNull = true;
		private decimal _porcentaje_hasta;
		private bool _porcentaje_hastaNull = true;
		private decimal _porcentaje_comision;
		private bool _porcentaje_comisionNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ESCALAS_COMISIONES_COBRADORESRow_Base"/> class.
		/// </summary>
		public ESCALAS_COMISIONES_COBRADORESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ESCALAS_COMISIONES_COBRADORESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.IsANHONull != original.IsANHONull) return true;
			if (!this.IsANHONull && !original.IsANHONull)
				if (this.ANHO != original.ANHO) return true;
			if (this.IsPORCENTAJE_HASTANull != original.IsPORCENTAJE_HASTANull) return true;
			if (!this.IsPORCENTAJE_HASTANull && !original.IsPORCENTAJE_HASTANull)
				if (this.PORCENTAJE_HASTA != original.PORCENTAJE_HASTA) return true;
			if (this.IsPORCENTAJE_COMISIONNull != original.IsPORCENTAJE_COMISIONNull) return true;
			if (!this.IsPORCENTAJE_COMISIONNull && !original.IsPORCENTAJE_COMISIONNull)
				if (this.PORCENTAJE_COMISION != original.PORCENTAJE_COMISION) return true;
			
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
		/// Gets or sets the <c>FUNCIONARIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FUNCIONARIO_ID</c> column value.</value>
		public decimal FUNCIONARIO_ID
		{
			get
			{
				if(IsFUNCIONARIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _funcionario_id;
			}
			set
			{
				_funcionario_idNull = false;
				_funcionario_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FUNCIONARIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFUNCIONARIO_IDNull
		{
			get { return _funcionario_idNull; }
			set { _funcionario_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ANHO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ANHO</c> column value.</value>
		public decimal ANHO
		{
			get
			{
				if(IsANHONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _anho;
			}
			set
			{
				_anhoNull = false;
				_anho = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ANHO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsANHONull
		{
			get { return _anhoNull; }
			set { _anhoNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE_HASTA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE_HASTA</c> column value.</value>
		public decimal PORCENTAJE_HASTA
		{
			get
			{
				if(IsPORCENTAJE_HASTANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje_hasta;
			}
			set
			{
				_porcentaje_hastaNull = false;
				_porcentaje_hasta = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE_HASTA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJE_HASTANull
		{
			get { return _porcentaje_hastaNull; }
			set { _porcentaje_hastaNull = value; }
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
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ID=");
			dynStr.Append(ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@ANHO=");
			dynStr.Append(IsANHONull ? (object)"<NULL>" : ANHO);
			dynStr.Append("@CBA@PORCENTAJE_HASTA=");
			dynStr.Append(IsPORCENTAJE_HASTANull ? (object)"<NULL>" : PORCENTAJE_HASTA);
			dynStr.Append("@CBA@PORCENTAJE_COMISION=");
			dynStr.Append(IsPORCENTAJE_COMISIONNull ? (object)"<NULL>" : PORCENTAJE_COMISION);
			return dynStr.ToString();
		}
	} // End of ESCALAS_COMISIONES_COBRADORESRow_Base class
} // End of namespace
