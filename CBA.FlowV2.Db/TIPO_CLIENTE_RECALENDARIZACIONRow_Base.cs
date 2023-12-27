// <fileinfo name="TIPO_CLIENTE_RECALENDARIZACIONRow_Base.cs">
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
	/// The base class for <see cref="TIPO_CLIENTE_RECALENDARIZACIONRow"/> that 
	/// represents a record in the <c>TIPO_CLIENTE_RECALENDARIZACION</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="TIPO_CLIENTE_RECALENDARIZACIONRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class TIPO_CLIENTE_RECALENDARIZACIONRow_Base
	{
		private decimal _id;
		private decimal _tipo_cliente_id;
		private bool _tipo_cliente_idNull = true;
		private decimal _dias_minimos;
		private bool _dias_minimosNull = true;
		private decimal _dias_maximos;
		private bool _dias_maximosNull = true;
		private decimal _dias_defecto;
		private bool _dias_defectoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="TIPO_CLIENTE_RECALENDARIZACIONRow_Base"/> class.
		/// </summary>
		public TIPO_CLIENTE_RECALENDARIZACIONRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(TIPO_CLIENTE_RECALENDARIZACIONRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsTIPO_CLIENTE_IDNull != original.IsTIPO_CLIENTE_IDNull) return true;
			if (!this.IsTIPO_CLIENTE_IDNull && !original.IsTIPO_CLIENTE_IDNull)
				if (this.TIPO_CLIENTE_ID != original.TIPO_CLIENTE_ID) return true;
			if (this.IsDIAS_MINIMOSNull != original.IsDIAS_MINIMOSNull) return true;
			if (!this.IsDIAS_MINIMOSNull && !original.IsDIAS_MINIMOSNull)
				if (this.DIAS_MINIMOS != original.DIAS_MINIMOS) return true;
			if (this.IsDIAS_MAXIMOSNull != original.IsDIAS_MAXIMOSNull) return true;
			if (!this.IsDIAS_MAXIMOSNull && !original.IsDIAS_MAXIMOSNull)
				if (this.DIAS_MAXIMOS != original.DIAS_MAXIMOS) return true;
			if (this.IsDIAS_DEFECTONull != original.IsDIAS_DEFECTONull) return true;
			if (!this.IsDIAS_DEFECTONull && !original.IsDIAS_DEFECTONull)
				if (this.DIAS_DEFECTO != original.DIAS_DEFECTO) return true;
			
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
		/// Gets or sets the <c>TIPO_CLIENTE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>TIPO_CLIENTE_ID</c> column value.</value>
		public decimal TIPO_CLIENTE_ID
		{
			get
			{
				if(IsTIPO_CLIENTE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _tipo_cliente_id;
			}
			set
			{
				_tipo_cliente_idNull = false;
				_tipo_cliente_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="TIPO_CLIENTE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsTIPO_CLIENTE_IDNull
		{
			get { return _tipo_cliente_idNull; }
			set { _tipo_cliente_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_MINIMOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIAS_MINIMOS</c> column value.</value>
		public decimal DIAS_MINIMOS
		{
			get
			{
				if(IsDIAS_MINIMOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dias_minimos;
			}
			set
			{
				_dias_minimosNull = false;
				_dias_minimos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIAS_MINIMOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIAS_MINIMOSNull
		{
			get { return _dias_minimosNull; }
			set { _dias_minimosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_MAXIMOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIAS_MAXIMOS</c> column value.</value>
		public decimal DIAS_MAXIMOS
		{
			get
			{
				if(IsDIAS_MAXIMOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dias_maximos;
			}
			set
			{
				_dias_maximosNull = false;
				_dias_maximos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIAS_MAXIMOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIAS_MAXIMOSNull
		{
			get { return _dias_maximosNull; }
			set { _dias_maximosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DIAS_DEFECTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DIAS_DEFECTO</c> column value.</value>
		public decimal DIAS_DEFECTO
		{
			get
			{
				if(IsDIAS_DEFECTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _dias_defecto;
			}
			set
			{
				_dias_defectoNull = false;
				_dias_defecto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="DIAS_DEFECTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsDIAS_DEFECTONull
		{
			get { return _dias_defectoNull; }
			set { _dias_defectoNull = value; }
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
			dynStr.Append("@CBA@TIPO_CLIENTE_ID=");
			dynStr.Append(IsTIPO_CLIENTE_IDNull ? (object)"<NULL>" : TIPO_CLIENTE_ID);
			dynStr.Append("@CBA@DIAS_MINIMOS=");
			dynStr.Append(IsDIAS_MINIMOSNull ? (object)"<NULL>" : DIAS_MINIMOS);
			dynStr.Append("@CBA@DIAS_MAXIMOS=");
			dynStr.Append(IsDIAS_MAXIMOSNull ? (object)"<NULL>" : DIAS_MAXIMOS);
			dynStr.Append("@CBA@DIAS_DEFECTO=");
			dynStr.Append(IsDIAS_DEFECTONull ? (object)"<NULL>" : DIAS_DEFECTO);
			return dynStr.ToString();
		}
	} // End of TIPO_CLIENTE_RECALENDARIZACIONRow_Base class
} // End of namespace
