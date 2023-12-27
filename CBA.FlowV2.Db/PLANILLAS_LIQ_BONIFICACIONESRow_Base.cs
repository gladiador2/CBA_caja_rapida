// <fileinfo name="PLANILLAS_LIQ_BONIFICACIONESRow_Base.cs">
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
	/// The base class for <see cref="PLANILLAS_LIQ_BONIFICACIONESRow"/> that 
	/// represents a record in the <c>PLANILLAS_LIQ_BONIFICACIONES</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="PLANILLAS_LIQ_BONIFICACIONESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class PLANILLAS_LIQ_BONIFICACIONESRow_Base
	{
		private decimal _montobonificacion;
		private bool _montobonificacionNull = true;
		private decimal _liquidacion_id;
		private bool _liquidacion_idNull = true;
		private decimal _funcionario_id;
		private bool _funcionario_idNull = true;
		private string _nombre_bonificacion;
		private decimal _planilla_liq_id;
		private bool _planilla_liq_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="PLANILLAS_LIQ_BONIFICACIONESRow_Base"/> class.
		/// </summary>
		public PLANILLAS_LIQ_BONIFICACIONESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(PLANILLAS_LIQ_BONIFICACIONESRow_Base original)
		{
			if (this.IsMONTOBONIFICACIONNull != original.IsMONTOBONIFICACIONNull) return true;
			if (!this.IsMONTOBONIFICACIONNull && !original.IsMONTOBONIFICACIONNull)
				if (this.MONTOBONIFICACION != original.MONTOBONIFICACION) return true;
			if (this.IsLIQUIDACION_IDNull != original.IsLIQUIDACION_IDNull) return true;
			if (!this.IsLIQUIDACION_IDNull && !original.IsLIQUIDACION_IDNull)
				if (this.LIQUIDACION_ID != original.LIQUIDACION_ID) return true;
			if (this.IsFUNCIONARIO_IDNull != original.IsFUNCIONARIO_IDNull) return true;
			if (!this.IsFUNCIONARIO_IDNull && !original.IsFUNCIONARIO_IDNull)
				if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.NOMBRE_BONIFICACION != original.NOMBRE_BONIFICACION) return true;
			if (this.IsPLANILLA_LIQ_IDNull != original.IsPLANILLA_LIQ_IDNull) return true;
			if (!this.IsPLANILLA_LIQ_IDNull && !original.IsPLANILLA_LIQ_IDNull)
				if (this.PLANILLA_LIQ_ID != original.PLANILLA_LIQ_ID) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTOBONIFICACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTOBONIFICACION</c> column value.</value>
		public decimal MONTOBONIFICACION
		{
			get
			{
				if(IsMONTOBONIFICACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _montobonificacion;
			}
			set
			{
				_montobonificacionNull = false;
				_montobonificacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTOBONIFICACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTOBONIFICACIONNull
		{
			get { return _montobonificacionNull; }
			set { _montobonificacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>LIQUIDACION_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LIQUIDACION_ID</c> column value.</value>
		public decimal LIQUIDACION_ID
		{
			get
			{
				if(IsLIQUIDACION_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _liquidacion_id;
			}
			set
			{
				_liquidacion_idNull = false;
				_liquidacion_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LIQUIDACION_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLIQUIDACION_IDNull
		{
			get { return _liquidacion_idNull; }
			set { _liquidacion_idNull = value; }
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
		/// Gets or sets the <c>NOMBRE_BONIFICACION</c> column value.
		/// </summary>
		/// <value>The <c>NOMBRE_BONIFICACION</c> column value.</value>
		public string NOMBRE_BONIFICACION
		{
			get { return _nombre_bonificacion; }
			set { _nombre_bonificacion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PLANILLA_LIQ_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PLANILLA_LIQ_ID</c> column value.</value>
		public decimal PLANILLA_LIQ_ID
		{
			get
			{
				if(IsPLANILLA_LIQ_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _planilla_liq_id;
			}
			set
			{
				_planilla_liq_idNull = false;
				_planilla_liq_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PLANILLA_LIQ_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPLANILLA_LIQ_IDNull
		{
			get { return _planilla_liq_idNull; }
			set { _planilla_liq_idNull = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@MONTOBONIFICACION=");
			dynStr.Append(IsMONTOBONIFICACIONNull ? (object)"<NULL>" : MONTOBONIFICACION);
			dynStr.Append("@CBA@LIQUIDACION_ID=");
			dynStr.Append(IsLIQUIDACION_IDNull ? (object)"<NULL>" : LIQUIDACION_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(IsFUNCIONARIO_IDNull ? (object)"<NULL>" : FUNCIONARIO_ID);
			dynStr.Append("@CBA@NOMBRE_BONIFICACION=");
			dynStr.Append(NOMBRE_BONIFICACION);
			dynStr.Append("@CBA@PLANILLA_LIQ_ID=");
			dynStr.Append(IsPLANILLA_LIQ_IDNull ? (object)"<NULL>" : PLANILLA_LIQ_ID);
			return dynStr.ToString();
		}
	} // End of PLANILLAS_LIQ_BONIFICACIONESRow_Base class
} // End of namespace
