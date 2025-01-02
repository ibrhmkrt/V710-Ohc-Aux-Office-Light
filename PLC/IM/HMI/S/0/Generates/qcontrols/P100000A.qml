import QtQuick 2.7
import "qrc:/"
IGuiPage
{
	id: q16777226
	objId: 16777226
	x: 0
	y: 0
	width: 480
	height: 272
	IGuiDiagnosticView
	{
		id: q788529152
		objId: 788529152
		x: 77
		y: 50
		width: 392
		height: 175
		qm_BorderCornerRadius: 4
		qm_BorderWidth: 1
		qm_RectangleBorder.color:"#ff6b717b"
		qm_FillColor: "#f7f3f7"
		qm_headerBackColor: "#f7f3f7"
		qm_toolBarBackColor: "#f7f3f7"
		qm_headerTextColor: "#ff424952"
		qm_headerValueVarTextAlignmentHorizontal: Text.AlignLeft
		qm_headerValueVarTextAlignmentVertical: Text.AlignVCenter
		qm_headerMarginLeft: 2
		qm_headerMarginRight: 1
		qm_headerMarginBottom: 1
		qm_headerMarginTop: 1
		qm_FocusWidth: 2
		qm_FocusColor: "#ffa5cfd6"
		qm_diagViewToolbarPosX: 2
		qm_diagViewToolbarPosY: 131
		qm_diagViewToolbarWidth: 388
		qm_diagViewToolbarHeight: 42
		qm_Font.pixelSize: 11
		qm_Font.family: "Tahoma"
		qm_Font.bold: true
		qm_diagViewCornerRadius: 4
		qm_DiagnosticListComponent: [
			Component
			{
				IGuiListCtrl
				{
					id: qu788529152
					objectName: "qu788529152"
					x: 8
					y: 27
					width: 376
					height: 103
					qm_list.qm_linesPerRow: 1
					qm_list.qm_tableRowHeight: 13
					qm_list.qm_tableMarginLeft: 2
					qm_list.qm_tableMarginRight: 1
					qm_list.qm_tableMarginBottom: 1
					qm_list.qm_tableMarginTop: 1
					qm_list.qm_tableBackColor: "#ffffffff"
					qm_list.qm_tableSelectBackColor: "#ff94b6e7"
					qm_list.qm_tableAlternateBackColor: "#ffe7e7ef"
					qm_list.qm_tableTextColor: "#ff424952"
					qm_list.qm_tableSelectTextColor: "#ff424952"
					qm_list.qm_tableAlternateTextColor: "#ff424952"
					qm_scrollCtrl: qus788529152

					qm_hasHeader: false
					qm_hasBorder: true
					qm_hasHorizontalScrollBar: true
					qm_hasVerticalScrollBar: true
					qm_list.qm_gridLineStyle: 0
					qm_list.qm_gridLineWidth: 1
					qm_list.qm_gridLineColor: "#ffffffff"
					qm_columnTypeList: [0, 0]
					totalColumnWidth: 378
					IGuiListScrollBarCtrl
					{
						id: qus788529152

					}
				}
			},
			Component
			{
				IGuiListCtrl
				{
					id: qu4294967295
					objectName: "qu4294967295"
					x: 8
					y: 27
					width: 376
					height: 103
					qm_list.qm_linesPerRow: 1
					qm_list.qm_tableRowHeight: 13
					qm_list.qm_tableMarginLeft: 2
					qm_list.qm_tableMarginRight: 1
					qm_list.qm_tableMarginBottom: 1
					qm_list.qm_tableMarginTop: 1
					qm_list.qm_tableBackColor: "#ffffffff"
					qm_list.qm_tableSelectBackColor: "#ff94b6e7"
					qm_list.qm_tableAlternateBackColor: "#ffe7e7ef"
					qm_list.qm_tableTextColor: "#ff424952"
					qm_list.qm_tableSelectTextColor: "#ff424952"
					qm_list.qm_tableAlternateTextColor: "#ff424952"
					qm_scrollCtrl: qus4294967295

					qm_hasHeader: true
					qm_hasBorder: true
					qm_hasHorizontalScrollBar: true
					qm_hasVerticalScrollBar: true
					qm_list.qm_gridLineStyle: 0
					qm_list.qm_gridLineWidth: 1
					qm_list.qm_gridLineColor: "#ffffffff"
					qm_columnTypeList: [1, 0, 0, 0, 0]
					totalColumnWidth: 558
					qm_headerItem: qh4294967295
					IGuiListHeader
					{
						id: qh4294967295
						qm_listItem: qu4294967295
						qm_columnWidthList: [24, 24, 100, 100, 310]
						color: "#ff84868c"
						qm_tableHeaderTextColor: "#ffffffff"
						qm_tableHeaderValueVarTextAlignmentHorizontal: Text.AlignLeft
						qm_tableHeaderValueVarTextAlignmentVertical: Text.AlignVCenter
						qm_tableHeaderMarginLeft: 3
						qm_tableHeaderMarginRight: 1
						qm_tableHeaderMarginBottom: 1
						qm_tableHeaderMarginTop: 1
						qm_noOfColumns: 5
						qm_tableHeaderHeight: 13
						qm_leftImageID: 45
						qm_leftTileTop: 4
						qm_leftTileBottom: 11
						qm_leftTileRight: 2
						qm_leftTileLeft: 4
						qm_middleImageID: 46
						qm_middleTileTop: 2
						qm_middleTileBottom: 13
						qm_middleTileRight: 2
						qm_middleTileLeft: 2
						qm_rightImageID: 47
						qm_rightTileTop: 4
						qm_rightTileBottom: 11
						qm_rightTileRight: 4
						qm_rightTileLeft: 2
						radius: 2
					}
					IGuiListScrollBarCtrl
					{
						id: qus4294967295

					}
				}
			},
			Component
			{
				IGuiListCtrl
				{
					id: qu4294967294
					objectName: "qu4294967294"
					x: 8
					y: 27
					width: 376
					height: 103
					qm_list.qm_linesPerRow: 1
					qm_list.qm_tableRowHeight: 13
					qm_list.qm_tableMarginLeft: 2
					qm_list.qm_tableMarginRight: 1
					qm_list.qm_tableMarginBottom: 1
					qm_list.qm_tableMarginTop: 1
					qm_list.qm_tableBackColor: "#ffffffff"
					qm_list.qm_tableSelectBackColor: "#ff94b6e7"
					qm_list.qm_tableAlternateBackColor: "#ffe7e7ef"
					qm_list.qm_tableTextColor: "#ff424952"
					qm_list.qm_tableSelectTextColor: "#ff424952"
					qm_list.qm_tableAlternateTextColor: "#ff424952"
					qm_scrollCtrl: qus4294967294

					qm_hasHeader: false
					qm_hasBorder: true
					qm_hasHorizontalScrollBar: true
					qm_hasVerticalScrollBar: true
					qm_list.qm_gridLineStyle: 0
					qm_list.qm_gridLineWidth: 1
					qm_list.qm_gridLineColor: "#ffffffff"
					qm_columnTypeList: [0]
					totalColumnWidth: 378
					IGuiListScrollBarCtrl
					{
						id: qus4294967294

					}
				}
			}
		]
		IGuiGraphicButton
		{
			id: q486539311
			objId: 486539311
			x: 56
			y: 136
			width: 44
			height: 32
			qm_BorderCornerRadius: 3
			qm_BorderWidth: 1
			qm_ImageSource: "image://QSmartImageProvider/48#2#4#128#0#0"
			qm_Border.top: 15
			qm_Border.bottom: 15
			qm_Border.right: 5
			qm_Border.left: 5
			qm_FillColor: "#ffefebef"
			qm_FocusWidth: 2
			qm_FocusColor: "#ffa5cfd6"
			qm_ImageFillMode:6
			qm_ImagePossitionX: 3
			qm_ImagePossitionY: 2
			qm_ImageWidth: 39
			qm_ImageHeight: 28
			qm_SourceSizeWidth: 39
			qm_SourceSizeHeight: 28
		}
		IGuiGraphicButton
		{
			id: q486539312
			objId: 486539312
			x: 105
			y: 136
			width: 44
			height: 32
			qm_BorderCornerRadius: 3
			qm_BorderWidth: 1
			qm_ImageSource: "image://QSmartImageProvider/48#2#4#128#0#0"
			qm_Border.top: 15
			qm_Border.bottom: 15
			qm_Border.right: 5
			qm_Border.left: 5
			qm_FillColor: "#ffefebef"
			qm_FocusWidth: 2
			qm_FocusColor: "#ffa5cfd6"
			qm_ImageFillMode:6
			qm_ImagePossitionX: 3
			qm_ImagePossitionY: 2
			qm_ImageWidth: 39
			qm_ImageHeight: 28
			qm_SourceSizeWidth: 39
			qm_SourceSizeHeight: 28
		}
		IGuiGraphicButton
		{
			id: q486539313
			objId: 486539313
			x: 154
			y: 136
			width: 44
			height: 32
			qm_BorderCornerRadius: 3
			qm_BorderWidth: 1
			qm_ImageSource: "image://QSmartImageProvider/48#2#4#128#0#0"
			qm_Border.top: 15
			qm_Border.bottom: 15
			qm_Border.right: 5
			qm_Border.left: 5
			qm_FillColor: "#ffefebef"
			qm_FocusWidth: 2
			qm_FocusColor: "#ffa5cfd6"
			qm_ImageFillMode:6
			qm_ImagePossitionX: 3
			qm_ImagePossitionY: 2
			qm_ImageWidth: 39
			qm_ImageHeight: 28
			qm_SourceSizeWidth: 39
			qm_SourceSizeHeight: 28
		}
		IGuiGraphicButton
		{
			id: q486539314
			objId: 486539314
			x: 7
			y: 136
			width: 44
			height: 32
			qm_BorderCornerRadius: 3
			qm_BorderWidth: 1
			qm_ImageSource: "image://QSmartImageProvider/48#2#4#128#0#0"
			qm_Border.top: 15
			qm_Border.bottom: 15
			qm_Border.right: 5
			qm_Border.left: 5
			qm_FillColor: "#ffefebef"
			qm_FocusWidth: 2
			qm_FocusColor: "#ffa5cfd6"
			qm_ImageFillMode:6
			qm_ImagePossitionX: 3
			qm_ImagePossitionY: 2
			qm_ImageWidth: 39
			qm_ImageHeight: 28
			qm_SourceSizeWidth: 39
			qm_SourceSizeHeight: 28
		}
		IGuiGraphicButton
		{
			id: q486539315
			objId: 486539315
			x: 154
			y: 136
			width: 44
			height: 32
			qm_BorderCornerRadius: 3
			qm_BorderWidth: 1
			qm_ImageSource: "image://QSmartImageProvider/48#2#4#128#0#0"
			qm_Border.top: 15
			qm_Border.bottom: 15
			qm_Border.right: 5
			qm_Border.left: 5
			qm_FillColor: "#ffefebef"
			qm_FocusWidth: 2
			qm_FocusColor: "#ffa5cfd6"
			qm_ImageFillMode:6
			qm_ImagePossitionX: 3
			qm_ImagePossitionY: 2
			qm_ImageWidth: 39
			qm_ImageHeight: 28
			qm_SourceSizeWidth: 39
			qm_SourceSizeHeight: 28
		}
	}
}
