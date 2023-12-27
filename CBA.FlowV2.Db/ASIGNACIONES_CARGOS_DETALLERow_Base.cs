// <fileinfo name="ASIGNACIONES_CARGOS_DETALLERow_Base.cs">
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
	/// The base class for <see cref="ASIGNACIONES_CARGOS_DETALLERow"/> that 
	/// represents a record in the <c>ASIGNACIONES_CARGOS_DETALLE</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ASIGNACIONES_CARGOS_DETALLERow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ASIGNACIONES_CARGOS_DETALLERow_Base
	{
		private decimal _id;
		private decimal _asignaciones_cargos_id;
		private decimal _funcionario_id;
		private decimal _empresa_cargo_id;
		private decimal _entidad_id;
		private decimal _sucursal_id;
		private bool _sucursal_idNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ASIGNACIONES_CARGOS_DETALLERow_Base"/> class.
		/// </summary>
		public ASIGNACIONES_CARGOS_DETALLERow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ASIGNACIONES_CARGOS_DETALLERow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.ASIGNACIONES_CARGOS_ID != original.ASIGNACIONES_CARGOS_ID) return true;
			if (this.FUNCIONARIO_ID != original.FUNCIONARIO_ID) return true;
			if (this.EMPRESA_CARGO_ID != original.EMPRESA_CARGO_ID) return true;
			if (this.ENTIDAD_ID != original.ENTIDAD_ID) return true;
			if (this.IsSUCURSAL_IDNull != original.IsSUCURSAL_IDNull) return true;
			if (!this.IsSUCURSAL_IDNull && !original.IsSUCURSAL_IDNull)
				if (this.SUCURSAL_ID != original.SUCURSAL_ID) return true;
			
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
		/// Gets or sets the <c>ASIGNACIONES_CARGOS_ID</c> column value.
		/// </summary>
		/// <value>The <c>ASIGNACIONES_CARGOS_ID</c> column value.</value>
		public decimal ASIGNACIONES_CARGOS_ID
		{
			get { return _asignaciones_cargos_id; }
			set { _asignaciones_cargos_id = value; }
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
		/// Gets or sets the <c>EMPRESA_CARGO_ID</c> column value.
		/// </summary>
		/// <value>The <c>EMPRESA_CARGO_ID</c> column value.</value>
		public decimal EMPRESA_CARGO_ID
		{
			get { return _empresa_cargo_id; }
			set { _empresa_cargo_id = value; }
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
		/// Gets or sets the <c>SUCURSAL_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUCURSAL_ID</c> column value.</value>
		public decimal SUCURSAL_ID
		{
			get
			{
				if(IsSUCURSAL_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _sucursal_id;
			}
			set
			{
				_sucursal_idNull = false;
				_sucursal_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUCURSAL_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUCURSAL_IDNull
		{
			get { return _sucursal_idNull; }
			set { _sucursal_idNull = value; }
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
			dynStr.Append("@CBA@ASIGNACIONES_CARGOS_ID=");
			dynStr.Append(ASIGNACIONES_CARGOS_ID);
			dynStr.Append("@CBA@FUNCIONARIO_ID=");
			dynStr.Append(FUNCIONARIO_ID);
			dynStr.Append("@CBA@EMPRESA_CARGO_ID=");
			dynStr.Append(EMPRESA_CARGO_ID);
			dynStr.Append("@CBA@ENTIDAD_ID=");
			dynStr.Append(ENTIDAD_ID);
			dynStr.Append("@CBA@SUCURSAL_ID=");
			dynStr.Append(IsSUCURSAL_IDNull ? (object)"<NULL>" : SUCURSAL_ID);
			return dynStr.ToString();
		}
	} // End of ASIGNACIONES_CARGOS_DETALLERow_Base class
} // End of namespace
