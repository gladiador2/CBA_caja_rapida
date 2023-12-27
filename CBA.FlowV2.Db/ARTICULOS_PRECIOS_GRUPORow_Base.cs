// <fileinfo name="ARTICULOS_PRECIOS_GRUPORow_Base.cs">
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
	/// The base class for <see cref="ARTICULOS_PRECIOS_GRUPORow"/> that 
	/// represents a record in the <c>ARTICULOS_PRECIOS_GRUPO</c> table.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="ARTICULOS_PRECIOS_GRUPORow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class ARTICULOS_PRECIOS_GRUPORow_Base
	{
		private decimal _id;
		private decimal _lista_precio_id;
		private bool _lista_precio_idNull = true;
		private decimal _articulos_grupo_id;
		private bool _articulos_grupo_idNull = true;
		private decimal _porcentaje;
		private bool _porcentajeNull = true;
		private decimal _monto;
		private bool _montoNull = true;

		/// <summary>
		/// Initializes a new instance of the <see cref="ARTICULOS_PRECIOS_GRUPORow_Base"/> class.
		/// </summary>
		public ARTICULOS_PRECIOS_GRUPORow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(ARTICULOS_PRECIOS_GRUPORow_Base original)
		{
			if (this.ID != original.ID) return true;
			if (this.IsLISTA_PRECIO_IDNull != original.IsLISTA_PRECIO_IDNull) return true;
			if (!this.IsLISTA_PRECIO_IDNull && !original.IsLISTA_PRECIO_IDNull)
				if (this.LISTA_PRECIO_ID != original.LISTA_PRECIO_ID) return true;
			if (this.IsARTICULOS_GRUPO_IDNull != original.IsARTICULOS_GRUPO_IDNull) return true;
			if (!this.IsARTICULOS_GRUPO_IDNull && !original.IsARTICULOS_GRUPO_IDNull)
				if (this.ARTICULOS_GRUPO_ID != original.ARTICULOS_GRUPO_ID) return true;
			if (this.IsPORCENTAJENull != original.IsPORCENTAJENull) return true;
			if (!this.IsPORCENTAJENull && !original.IsPORCENTAJENull)
				if (this.PORCENTAJE != original.PORCENTAJE) return true;
			if (this.IsMONTONull != original.IsMONTONull) return true;
			if (!this.IsMONTONull && !original.IsMONTONull)
				if (this.MONTO != original.MONTO) return true;
			
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
		/// Gets or sets the <c>LISTA_PRECIO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>LISTA_PRECIO_ID</c> column value.</value>
		public decimal LISTA_PRECIO_ID
		{
			get
			{
				if(IsLISTA_PRECIO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _lista_precio_id;
			}
			set
			{
				_lista_precio_idNull = false;
				_lista_precio_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="LISTA_PRECIO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsLISTA_PRECIO_IDNull
		{
			get { return _lista_precio_idNull; }
			set { _lista_precio_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULOS_GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULOS_GRUPO_ID</c> column value.</value>
		public decimal ARTICULOS_GRUPO_ID
		{
			get
			{
				if(IsARTICULOS_GRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulos_grupo_id;
			}
			set
			{
				_articulos_grupo_idNull = false;
				_articulos_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULOS_GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULOS_GRUPO_IDNull
		{
			get { return _articulos_grupo_idNull; }
			set { _articulos_grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>PORCENTAJE</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>PORCENTAJE</c> column value.</value>
		public decimal PORCENTAJE
		{
			get
			{
				if(IsPORCENTAJENull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _porcentaje;
			}
			set
			{
				_porcentajeNull = false;
				_porcentaje = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="PORCENTAJE"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsPORCENTAJENull
		{
			get { return _porcentajeNull; }
			set { _porcentajeNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>MONTO</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>MONTO</c> column value.</value>
		public decimal MONTO
		{
			get
			{
				if(IsMONTONull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _monto;
			}
			set
			{
				_montoNull = false;
				_monto = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="MONTO"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsMONTONull
		{
			get { return _montoNull; }
			set { _montoNull = value; }
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
			dynStr.Append("@CBA@LISTA_PRECIO_ID=");
			dynStr.Append(IsLISTA_PRECIO_IDNull ? (object)"<NULL>" : LISTA_PRECIO_ID);
			dynStr.Append("@CBA@ARTICULOS_GRUPO_ID=");
			dynStr.Append(IsARTICULOS_GRUPO_IDNull ? (object)"<NULL>" : ARTICULOS_GRUPO_ID);
			dynStr.Append("@CBA@PORCENTAJE=");
			dynStr.Append(IsPORCENTAJENull ? (object)"<NULL>" : PORCENTAJE);
			dynStr.Append("@CBA@MONTO=");
			dynStr.Append(IsMONTONull ? (object)"<NULL>" : MONTO);
			return dynStr.ToString();
		}
	} // End of ARTICULOS_PRECIOS_GRUPORow_Base class
} // End of namespace
