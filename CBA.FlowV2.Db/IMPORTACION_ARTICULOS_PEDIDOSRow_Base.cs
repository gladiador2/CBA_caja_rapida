// <fileinfo name="IMPORTACION_ARTICULOS_PEDIDOSRow_Base.cs">
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
	/// The base class for <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/> that 
	/// represents a record in the <c>IMPORTACION_ARTICULOS_PEDIDOS</c> view.
	/// </summary>
	/// <remarks>
	/// Do not change this source code manually. Update the <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow"/>
	/// class if you need to add or change some functionality.
	/// </remarks>
	public abstract class IMPORTACION_ARTICULOS_PEDIDOSRow_Base
	{
		private decimal _articulo_id;
		private bool _articulo_idNull = true;
		private decimal _cantidad_importacion;
		private bool _cantidad_importacionNull = true;
		private decimal _cantidad_pedidos;
		private bool _cantidad_pedidosNull = true;
		private string _descripcion_interna;
		private decimal _existencia;
		private bool _existenciaNull = true;
		private decimal _familia_id;
		private bool _familia_idNull = true;
		private string _familia_descripcion;
		private decimal _grupo_id;
		private bool _grupo_idNull = true;
		private string _grupo_descripcion;
		private decimal _subgrupo_id;
		private bool _subgrupo_idNull = true;
		private string _subgrupo_descripcion;

		/// <summary>
		/// Initializes a new instance of the <see cref="IMPORTACION_ARTICULOS_PEDIDOSRow_Base"/> class.
		/// </summary>
		public IMPORTACION_ARTICULOS_PEDIDOSRow_Base()
		{
			// EMPTY
		}

		/// <summary>
		/// Comparar contra el objeto pasado como parametro.
		/// </summary>
		public bool FueModificado(IMPORTACION_ARTICULOS_PEDIDOSRow_Base original)
		{
			if (this.IsARTICULO_IDNull != original.IsARTICULO_IDNull) return true;
			if (!this.IsARTICULO_IDNull && !original.IsARTICULO_IDNull)
				if (this.ARTICULO_ID != original.ARTICULO_ID) return true;
			if (this.IsCANTIDAD_IMPORTACIONNull != original.IsCANTIDAD_IMPORTACIONNull) return true;
			if (!this.IsCANTIDAD_IMPORTACIONNull && !original.IsCANTIDAD_IMPORTACIONNull)
				if (this.CANTIDAD_IMPORTACION != original.CANTIDAD_IMPORTACION) return true;
			if (this.IsCANTIDAD_PEDIDOSNull != original.IsCANTIDAD_PEDIDOSNull) return true;
			if (!this.IsCANTIDAD_PEDIDOSNull && !original.IsCANTIDAD_PEDIDOSNull)
				if (this.CANTIDAD_PEDIDOS != original.CANTIDAD_PEDIDOS) return true;
			if (this.DESCRIPCION_INTERNA != original.DESCRIPCION_INTERNA) return true;
			if (this.IsEXISTENCIANull != original.IsEXISTENCIANull) return true;
			if (!this.IsEXISTENCIANull && !original.IsEXISTENCIANull)
				if (this.EXISTENCIA != original.EXISTENCIA) return true;
			if (this.IsFAMILIA_IDNull != original.IsFAMILIA_IDNull) return true;
			if (!this.IsFAMILIA_IDNull && !original.IsFAMILIA_IDNull)
				if (this.FAMILIA_ID != original.FAMILIA_ID) return true;
			if (this.FAMILIA_DESCRIPCION != original.FAMILIA_DESCRIPCION) return true;
			if (this.IsGRUPO_IDNull != original.IsGRUPO_IDNull) return true;
			if (!this.IsGRUPO_IDNull && !original.IsGRUPO_IDNull)
				if (this.GRUPO_ID != original.GRUPO_ID) return true;
			if (this.GRUPO_DESCRIPCION != original.GRUPO_DESCRIPCION) return true;
			if (this.IsSUBGRUPO_IDNull != original.IsSUBGRUPO_IDNull) return true;
			if (!this.IsSUBGRUPO_IDNull && !original.IsSUBGRUPO_IDNull)
				if (this.SUBGRUPO_ID != original.SUBGRUPO_ID) return true;
			if (this.SUBGRUPO_DESCRIPCION != original.SUBGRUPO_DESCRIPCION) return true;
			
			return false;
		}
		
		/// <summary>
		/// Gets or sets the <c>ARTICULO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>ARTICULO_ID</c> column value.</value>
		public decimal ARTICULO_ID
		{
			get
			{
				if(IsARTICULO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _articulo_id;
			}
			set
			{
				_articulo_idNull = false;
				_articulo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="ARTICULO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsARTICULO_IDNull
		{
			get { return _articulo_idNull; }
			set { _articulo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_IMPORTACION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_IMPORTACION</c> column value.</value>
		public decimal CANTIDAD_IMPORTACION
		{
			get
			{
				if(IsCANTIDAD_IMPORTACIONNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_importacion;
			}
			set
			{
				_cantidad_importacionNull = false;
				_cantidad_importacion = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_IMPORTACION"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_IMPORTACIONNull
		{
			get { return _cantidad_importacionNull; }
			set { _cantidad_importacionNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>CANTIDAD_PEDIDOS</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>CANTIDAD_PEDIDOS</c> column value.</value>
		public decimal CANTIDAD_PEDIDOS
		{
			get
			{
				if(IsCANTIDAD_PEDIDOSNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _cantidad_pedidos;
			}
			set
			{
				_cantidad_pedidosNull = false;
				_cantidad_pedidos = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="CANTIDAD_PEDIDOS"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsCANTIDAD_PEDIDOSNull
		{
			get { return _cantidad_pedidosNull; }
			set { _cantidad_pedidosNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>DESCRIPCION_INTERNA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>DESCRIPCION_INTERNA</c> column value.</value>
		public string DESCRIPCION_INTERNA
		{
			get { return _descripcion_interna; }
			set { _descripcion_interna = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>EXISTENCIA</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>EXISTENCIA</c> column value.</value>
		public decimal EXISTENCIA
		{
			get
			{
				if(IsEXISTENCIANull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _existencia;
			}
			set
			{
				_existenciaNull = false;
				_existencia = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="EXISTENCIA"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsEXISTENCIANull
		{
			get { return _existenciaNull; }
			set { _existenciaNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_ID</c> column value.</value>
		public decimal FAMILIA_ID
		{
			get
			{
				if(IsFAMILIA_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _familia_id;
			}
			set
			{
				_familia_idNull = false;
				_familia_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="FAMILIA_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsFAMILIA_IDNull
		{
			get { return _familia_idNull; }
			set { _familia_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>FAMILIA_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>FAMILIA_DESCRIPCION</c> column value.</value>
		public string FAMILIA_DESCRIPCION
		{
			get { return _familia_descripcion; }
			set { _familia_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_ID</c> column value.</value>
		public decimal GRUPO_ID
		{
			get
			{
				if(IsGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _grupo_id;
			}
			set
			{
				_grupo_idNull = false;
				_grupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="GRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsGRUPO_IDNull
		{
			get { return _grupo_idNull; }
			set { _grupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>GRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>GRUPO_DESCRIPCION</c> column value.</value>
		public string GRUPO_DESCRIPCION
		{
			get { return _grupo_descripcion; }
			set { _grupo_descripcion = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_ID</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_ID</c> column value.</value>
		public decimal SUBGRUPO_ID
		{
			get
			{
				if(IsSUBGRUPO_IDNull)
					throw new InvalidOperationException("Cannot get value because it is DBNull.");
				return _subgrupo_id;
			}
			set
			{
				_subgrupo_idNull = false;
				_subgrupo_id = value;
			}
		}

		/// <summary>
		/// Indicates whether the <see cref="SUBGRUPO_ID"/>
		/// property value is null.
		/// </summary>
		/// <value>true if the property value is null, otherwise false.</value>
		public bool IsSUBGRUPO_IDNull
		{
			get { return _subgrupo_idNull; }
			set { _subgrupo_idNull = value; }
		}
		
		/// <summary>
		/// Gets or sets the <c>SUBGRUPO_DESCRIPCION</c> column value.
		/// This column is nullable.
		/// </summary>
		/// <value>The <c>SUBGRUPO_DESCRIPCION</c> column value.</value>
		public string SUBGRUPO_DESCRIPCION
		{
			get { return _subgrupo_descripcion; }
			set { _subgrupo_descripcion = value; }
		}
		
		/// <summary>
		/// Returns the string representation of this instance.
		/// </summary>
		/// <returns>The string representation of this instance.</returns>
		public override string ToString()
		{
			System.Text.StringBuilder dynStr = new System.Text.StringBuilder(GetType().Name);
			dynStr.Append(':');
			dynStr.Append("@CBA@ARTICULO_ID=");
			dynStr.Append(IsARTICULO_IDNull ? (object)"<NULL>" : ARTICULO_ID);
			dynStr.Append("@CBA@CANTIDAD_IMPORTACION=");
			dynStr.Append(IsCANTIDAD_IMPORTACIONNull ? (object)"<NULL>" : CANTIDAD_IMPORTACION);
			dynStr.Append("@CBA@CANTIDAD_PEDIDOS=");
			dynStr.Append(IsCANTIDAD_PEDIDOSNull ? (object)"<NULL>" : CANTIDAD_PEDIDOS);
			dynStr.Append("@CBA@DESCRIPCION_INTERNA=");
			dynStr.Append(DESCRIPCION_INTERNA);
			dynStr.Append("@CBA@EXISTENCIA=");
			dynStr.Append(IsEXISTENCIANull ? (object)"<NULL>" : EXISTENCIA);
			dynStr.Append("@CBA@FAMILIA_ID=");
			dynStr.Append(IsFAMILIA_IDNull ? (object)"<NULL>" : FAMILIA_ID);
			dynStr.Append("@CBA@FAMILIA_DESCRIPCION=");
			dynStr.Append(FAMILIA_DESCRIPCION);
			dynStr.Append("@CBA@GRUPO_ID=");
			dynStr.Append(IsGRUPO_IDNull ? (object)"<NULL>" : GRUPO_ID);
			dynStr.Append("@CBA@GRUPO_DESCRIPCION=");
			dynStr.Append(GRUPO_DESCRIPCION);
			dynStr.Append("@CBA@SUBGRUPO_ID=");
			dynStr.Append(IsSUBGRUPO_IDNull ? (object)"<NULL>" : SUBGRUPO_ID);
			dynStr.Append("@CBA@SUBGRUPO_DESCRIPCION=");
			dynStr.Append(SUBGRUPO_DESCRIPCION);
			return dynStr.ToString();
		}
	} // End of IMPORTACION_ARTICULOS_PEDIDOSRow_Base class
} // End of namespace
