// <fileinfo name="CONTENEDORES_DETALLESRow_Base.cs">
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
	/// The base class for <see cref="CONTENEDORES_DETALLESRow"/> that 
	/// represents a record in the <c>CONTENEDORES_DETALLES</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="CONTENEDORES_DETALLESRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class CONTENEDORES_DETALLESRow_Base
	{
		private decimal _id;
		private decimal _conocimiento_detalle_id;
		private bool _conocimiento_detalle_idNull = true;
		private decimal _cantidad;
		private bool _cantidadNull = true;
		private decimal _conocimientos_contenidos_id;
		private bool _conocimientos_contenidos_idNull = true;
		private string _observacion;

		/// <summary>
		/// Initializes a new instance of the <see cref="CONTENEDORES_DETALLESRow_Base"/> class.
		/// </summary>
		public CONTENEDORES_DETALLESRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(CONTENEDORES_DETALLESRow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsCONOCIMIENTO_DETALLE_IDNull != original.IsCONOCIMIENTO_DETALLE_IDNull) return true;
			if (!this.IsCONOCIMIENTO_DETALLE_IDNull && !original.IsCONOCIMIENTO_DETALLE_IDNull)
				if (this.CONOCIMIENTO_DETALLE_ID != original.CONOCIMIENTO_DETALLE_ID) return true;
			if (this.IsCANTIDADNull != original.IsCANTIDADNull) return true;
			if (!this.IsCANTIDADNull && !original.IsCANTIDADNull)
				if (this.CANTIDAD != original.CANTIDAD) return true;
			if (this.IsCONOCIMIENTOS_CONTENIDOS_IDNull != original.IsCONOCIMIENTOS_CONTENIDOS_IDNull) return true;
			if (!this.IsCONOCIMIENTOS_CONTENIDOS_IDNull && !original.IsCONOCIMIENTOS_CONTENIDOS_IDNull)
				if (this.CONOCIMIENTOS_CONTENIDOS_ID != original.CONOCIMIENTOS_CONTENIDOS_ID) return true;
			if (this.OBSERVACION != original.OBSERVACION) return true;
			
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
		/// Gets or sets the <c>CONOCIMIENTO_DETALLE_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONOCIMIENTO_DETALLE_ID</c> column value.</value>
		public decimal CONOCIMIENTO_DETALLE_ID
		{
			get
			{
				if(IsCONOCIMIENTO_DETALLE_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _conocimiento_detalle_id;
			}
			set
			{
				_conocimiento_detalle_idNull = false;
				_conocimiento_detalle_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONOCIMIENTO_DETALLE_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONOCIMIENTO_DETALLE_IDNull
		{
			get { return _conocimiento_detalle_idNull; }
			set { _conocimiento_detalle_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD</c> column value.</value>
		public decimal CANTIDAD
		{
			get
			{
				if(IsCANTIDADNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad;
			}
			set
			{
				_cantidadNull = false;
				_cantidad = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDADNull
		{
			get { return _cantidadNull; }
			set { _cantidadNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CONOCIMIENTOS_CONTENIDOS_ID</c> column value.</value>
		public decimal CONOCIMIENTOS_CONTENIDOS_ID
		{
			get
			{
				if(IsCONOCIMIENTOS_CONTENIDOS_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _conocimientos_contenidos_id;
			}
			set
			{
				_conocimientos_contenidos_idNull = false;
				_conocimientos_contenidos_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CONOCIMIENTOS_CONTENIDOS_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCONOCIMIENTOS_CONTENIDOS_IDNull
		{
			get { return _conocimientos_contenidos_idNull; }
			set { _conocimientos_contenidos_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>OBSERVACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>OBSERVACION</c> column value.</value>
		public string OBSERVACION
		{
			get { return _observacion; }
			set { _observacion = value; }
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
			dynStr.Append("@CBA@CONOCIMIENTO_DETALLE_ID=");
			dynStr.Append(IsCONOCIMIENTO_DETALLE_IDNull ? (object)"<NULL>" : CONOCIMIENTO_DETALLE_ID);
			dynStr.Append("@CBA@CANTIDAD=");
			dynStr.Append(IsCANTIDADNull ? (object)"<NULL>" : CANTIDAD);
			dynStr.Append("@CBA@CONOCIMIENTOS_CONTENIDOS_ID=");
			dynStr.Append(IsCONOCIMIENTOS_CONTENIDOS_IDNull ? (object)"<NULL>" : CONOCIMIENTOS_CONTENIDOS_ID);
			dynStr.Append("@CBA@OBSERVACION=");
			dynStr.Append(OBSERVACION);
			return dynStr.ToString();
		}
	} // End of CONTENEDORES_DETALLESRow_Base class
} // End of namespace
