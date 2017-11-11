CKEditor 4 Changelog
====================

## CKEditor 4.7.1

New Features:

* Added a new Mexican Spanish localization. Thanks to (https://www.transifex.com/user/profile/darsco16/)!
* (http://ckeditor.com/addon/a11yhelp) instructions.

Fixed Issues:

* (http://ckeditor.com/addon/tableselection) plugin is loaded.
* (https://github.com/ckeditor/ckeditor-dev/issues/493): Fixed: Selection started from a nested table causes an error in the browser while scrolling down.
*  Fixed: <kbd>Enter</kbd> key breaks the table structure when pressed in a table selection.
* (https://github.com/ckeditor/ckeditor-dev/issues/457): Fixed: Error thrown when deleting content from the editor with no selection.
* (http://ckeditor.com/addon/enterkey) plugin when pressing <kbd>Enter</kbd> with no selection.
* (http://ckeditor.com/addon/indentlist) plugins when pressing <kbd>Tab</kbd> with no selection in inline editor.
* (http://ckeditor.com/addon/link) plugin on collapsed selection cannot be edited.
* (http://ckeditor.com/addon/tableresize) plugin throws an error when used with a table with only header or footer rows.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getCommandKeystroke) method does not obtain the correct keystroke.
* (http://ckeditor.com/addon/pastefromword) does not work in Quirks Mode.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.filter) incorrectly transforms the `margin` CSS property.

## CKEditor 4.7

**Important Notes:**

* (http://ckeditor.com/addon/embedsemantic) plugins is no longer preset by default.
* The (http://ckeditor.com/addon/uicolor) plugin now uses a custom color picker instead of the `YUI 2.7.0` library which has some known vulnerabilities (it's a security precaution, there was no security issue in CKEditor due to the way it was used).

New Features:

* (http://ckeditor.com/addon/tableselection) plugin that lets you select and manipulate an arbitrary rectangular table fragment (a few cells, a row or a column).
* (http://dev.ckeditor.com/ticket/16961): Added support for pasting from Microsoft Excel.
* (http://caridy.name)!
* (http://ckeditor.com/addon/tabletools) plugin.
* (http://ckeditor.com/addon/pastefromword) plugin.
* (http://ckeditor.com/addon/pastefromword) plugin.
* (http://ckeditor.com/addon/contextmenu).
* (http://docs.ckeditor.dev/#!/api/CKEDITOR.editor-method-getCommandKeystroke) now also accepts a command name as an argument.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.range-method-shrink) method now allows for skipping bogus `<br>` elements.

Fixed Issues:

* (http://ckeditor.com/addon/sourcearea) throws an error.
*  Fixed: Error thrown when destroying a focused inline editor.
* (http://ckeditor.com/addon/copyformatting).
* (http://ckeditor.com/addon/copyformatting) plugin is enabled.
* (http://ckeditor.com/addon/copyformatting) plugin.
*  Fixed: Exception thrown on refocusing a blurred inline editor.
* (http://ckeditor.com/addon/pastetext) keystroke does not work.
* (http://ckeditor.com/addon/pastetext) is not handled by the editor.
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword), paragraphs are transformed into lists with some corrupted data.
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://dev.ckeditor.com/ticket/12465): Fixed: Cannot change the state of checkboxes or radio buttons if the properties dialog was invoked with a double-click.
* (http://dev.ckeditor.com/ticket/13062): Fixed: Impossible to unlink when the caret is at the edge of the link.
* (http://dev.ckeditor.com/ticket/13585): Fixed: Error when wrapping two adjacent `<div>` elements with a `<div>`.
* (http://ckeditor.com/addon/pastefromword) plugin.
* (http://ckeditor.com/addon/pastefromword) plugin.
* (http://ckeditor.com/addon/link) dialog does not open on a double click on the second word of the link with a background color or other styles.
* (http://ckeditor.com/addon/tableresize) on table header and footer.
* (http://ckeditor.com/addon/tableresize) plugin is active.
* (http://ckeditor.com/addon/clipboard) plugin does not allow to drop widgets into the editor.
*  Fixed: The editor scrolls to the top after focusing or when a dialog is opened.
* (http://ckeditor.com/addon/autolink) plugin.
* (https://dev.ckeditor.com/ticket/16804): Fixed: Focus is not on the first menu item when the user opens a context menu or a drop-down list from the editor toolbar.
*  Fixed: Non-editable widgets can be edited.
* (https://github.com/IgorRubinovich)!
* (http://ckeditor.com/addon/dialog) plugin as a direct dependency.
* (https://github.com/knusperpixel)!
* (http://dev.ckeditor.com/ticket/17027): Fixed: Command event data should be initialized as an empty object.
* Fixed the behavior of HTML parser when parsing `src`/`srcdoc` attributes of the `<iframe>` element in a CKEditor setup with ACF turned off and without the (http://docs.ckeditor.com/#!/guide/dev_best_practices-section-security), so the problem described above has not been considered a security issue as such.

Other Changes:

* Updated (http://ckeditor.com/addon/wsc) plugins:
	* Fixed: DOM Exception after clicking "Remove Language" on a selected word with enabled (http://ckeditor.com/addon/language) plugin in SCAYT.
* (https://cdnjs.com/), due to closing of `cdn.mathjax.org` scheduled for April 30, 2017.
* (http://dev.ckeditor.com/ticket/16954): Removed the paste dialog.
* (http://dev.ckeditor.com/ticket/16982): Latest Safari now supports enhanced Clipboard API introduced in CKEditor 4.5.0.
* (https://github.com/benderjs/benderjs) to 0.4.2.

## CKEditor 4.6.2

New Features:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-colorButton_colorsPerRow) configuration option for setting the number of rows in the color selector.
* (https://www.transifex.com/ckeditor/teams/11143/az/)!
* (http://docs.ckeditor.com/#!/guide/dev_styles-section-widget-styles), so applying one style disables the other.

Fixed Issues:

*  Fixed: It is possible to type in an unfocused inline editor.
* (http://ckeditor.com/addon/font) reset each other when modified at certain positions.
* (http://ckeditor.com/addon/pastefromword).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-pasteFromWord_heuristicsEdgeList) configuration option.
* (http://dev.ckeditor.com/ticket/10373): Fixed: Context menu items can be dragged into the editor.
* (http://ckeditor.com/addon/copyformatting) breaks the editor in Quirks Mode.
* (http://ckeditor.com/addon/copyformatting) breaks the editor in Compatibility Mode.
* (http://ckeditor.com/addon/copyformatting) to a single table cell are applied to the whole table.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-setSize) sets incorrect editor dimensions if the border width is represented as a fraction of pixels.
* (http://ckeditor.com/addon/clipboard).
* (http://ckeditor.com/addon/divarea).

## CKEditor 4.6.1

New Features:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.ajax-method-post) method became optional.

Fixed Issues:

* (http://ckeditor.com/addon/selectall) plugin.
*  Fixed: Browser hangs when a table is inserted in the place of a selected list with an empty last item.
* (http://ckeditor.com/addon/pastefromword).
*  Fixed: Error thrown occasionally by an uninitialized editable for multiple CKEditor instances on the same page.

## CKEditor 4.6

New Features:

* (http://docs.ckeditor.com/#!/guide/dev_colorbutton) feature).
* (http://ckeditor.com/addon/copyformatting) feature to enable easy copying of styles between your document parts.
* Introduced the completely rewritten (http://ckeditor.com/addon/pastefromword) plugin:
	* Backward incompatibility: The (http://docs.ckeditor.com/#!/guide/dev_acf) to replicate the effect of setting it to `true`.
	* Backward incompatibility: The (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-pasteFromWordRemoveStyles) options were dropped and no longer have any effect on pasted content.
	* Major improvements in preservation of list numbering, styling and indentation (nested lists with multiple levels).
	* Major improvements in document structure parsing that fix plenty of issues with distorted or missing content after paste.
* Added new translation: Occitan. Thanks to (https://totenoc.eu/)!
* (http://dev.ckeditor.com/ticket/10015): Keyboard shortcuts (relevant to the operating system in use) will now be displayed in tooltips and context menus.
* (http://ckeditor.com/addon/uploadimage) feature now uses `uploaded.width/height` if set.
* (http://ckeditor.com/addon/uploadfile) plugin that lets you upload a file by drag&amp;dropping it into the editor content.
* (http://ckeditor.com/addon/balloonpanel) plugin that lets you create stylish floating UI elements for the editor.
* (https://github.com/sbusse)!
* (http://docs.ckeditor.com/#!/api/CKEDITOR.fileTools.uploadWidgetDefinition-property-additionalRequestParameters) property for file uploads to make it possible to send additional information about the uploaded file to the server.
* (https://github.com/andreyfedoseev)!

Fixed Issues:

* (http://ckeditor.com/addon/pastefromword) should only normalize input data.
* (http://ckeditor.com/addon/pastefromword) correctly.
* (http://dev.ckeditor.com/ticket/14335): Fixed: Pasting a numbered list starting with a value different from "1" from Microsoft Word does not work correctly.
* (http://dev.ckeditor.com/ticket/14542): Fixed: Copying a numbered list from Microsoft Word does not preserve list formatting.
* (http://dev.ckeditor.com/ticket/14544): Fixed: Copying a nested list from Microsoft Word results in an empty list.
* (http://ckeditor.com/addon/pastefromword) breaks the styling in some cases.
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword) does not detect pasting a part of a paragraph.
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword), borders are missing on one side.
* (http://docs.ckeditor.com/#!/guide/dev_basicstyles-section-custom-basic-text-style-definition).
* (http://ckeditor.com/addon/pastefromword) is extremely slow.
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword) differently than in other browsers.
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword) inserts empty paragraphs.
* (http://ckeditor.com/addon/pastefromword) inserts a blank line at the top.
* (http://ckeditor.com/addon/pastefromword) content cleanup breaking content formatting.
* (http://ckeditor.com/addon/pastefromword).
* (http://docs.ckeditor.com/#!/api/CKEDITOR-property-ENTER_BR).
* (http://ckeditor.com/addon/pastefromword) creates a simple Caesar cipher.
* (http://ckeditor.com/addon/pastefromword) leaves an unwanted `color:windowtext` style.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-pasteFromWordRemoveFontStyles) is ignored under certain conditions.
* (http://ckeditor.com/addon/pastefromword) dialog.
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://ckeditor.com/addon/pastefromword).
* (http://dev.ckeditor.com/ticket/13828): Fixed: Widget classes should be added to the wrapper rather than the widget element.
* (http://ckeditor.com/addon/widget) wrapper to identify the widget type.
* (http://dev.ckeditor.com/ticket/13519): Server response received when uploading files should be more flexible.

Other Changes:

* Updated (http://ckeditor.com/addon/wsc) plugins:
 	* Support for the new default Moono-Lisa skin.
 	* (http://ckeditor.com/addon/basicstyles) do not work when SCAYT is enabled.
 	* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/125): Fixed: Inline styles are not continued when writing multiple lines of styled text with SCAYT enabled.
 	* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/127): Fixed: Uncaught TypeError after enabling SCAYT in the CKEditor `<div>` element.
 	* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/128): Fixed: Error thrown after enabling SCAYT caused by conflicts with RequireJS.

## CKEditor 4.5.11

**Security Updates:**

*  Fixed the `target="_blank"` vulnerability reported by James Gaskell.

	Issue summary: If a victim had access to a spoofed version of ckeditor.com via HTTP (e.g. due to DNS spoofing, using a hacked public network or mailicious hotspot), then when using a link to the ckeditor.com website it was possible for the attacker to change the current URL of the opening page, even if the opening page was protected with SSL.

  An upgrade is recommended.

New Features:

* (http://ckeditor.com/addon/image2) caption now supports the link `target` attribute.
* (https://github.com/ryanguill)!

Fixed Issues:

*  Fixed: Active widget element is not cached when it is losing focus and it is inside an editable element.
*  Fixed: Pasting images does not work.
* (http://ckeditor.com/addon/elementspath) disables Cut and Copy icons.
* (http://dev.ckeditor.com/ticket/13812): Fixed: When aborting file upload the placeholder for image is left.
* (http://ckeditor.com/addon/divarea).
*  Fixed: Focusing the editor causes unwanted scrolling due to dropped support for the `setActive` method.

## CKEditor 4.5.10

Fixed Issues:

* (http://dev.ckeditor.com/ticket/10750): Fixed: The editor does not escape the `font-style` family property correctly, removing quotes and whitespace from font names.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-autoGrow_onStartup) option set to `true` does not work properly for an editor that is not visible.
* (https://github.com/chaluja7)!
* (https://github.com/dpidcock)!
* (https://dev.ckeditor.com/ticket/14539): Fixed: JAWS reads "selected Blank" instead of "selected <widget name>" when selecting a widget.
* (http://ckeditor.com/addon/placeholder) widgets.
*  Fixed: Removing background color from selected text removes background color from the whole paragraph.
*  Fixed: Styles drop-down list does not always reflect the current style of the text line.
*  Fixed: `onerror` and `onload` events are not used in browsers it could have been used when loading scripts dynamically.

## CKEditor 4.5.9

Fixed Issues:

* (https://github.com/ckeditor/ckeditor-presets).
* (http://ckeditor.com/addon/widget) drag handler CSS when there are multiple editor instances.
* (http://ckeditor.com/addon/autogrow) plugin.
* (http://dev.ckeditor.com/ticket/14538): Fixed: Keyboard focus goes into an embedded `<iframe>` element.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-removeAttribute) method does not remove all attributes if no parameter is given.
* (http://ckeditor.com/addon/colordialog).
* (http://ckeditor.com/addon/find) dialog window.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.filter).
* (https://github.com/mdjdenormandie)!

## CKEditor 4.5.8

New Features:

* (http://ckeditor.com/addon/colorbutton).

Fixed Issues:

* (http://ckeditor.com/addon/bidi).
* (http://dev.ckeditor.com/ticket/12707): Fixed: The order of table elements does not comply with the HTML specification.
*  Fixed: Context menus are cut-off.

## CKEditor 4.5.7

New Features:

* (https://twitter.com/mirogrenda)!

Fixed Issues:

* (http://dev.ckeditor.com/ticket/13816): Introduced a new strategy for Filling Character handling to avoid changes in DOM. This fixes the following issues:
	* (http://ckeditor.com/addon/templates) plugins.
	* (http://ckeditor.com/addon/widget) plugin issue when typing in Korean.
	* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getData) fails when the cursor is next to an `<hr>` tag.
	* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getData) throw an error when an image is the only data in the editor.
*  Fixed: Copying and pasting a table results in just the first cell being pasted.
* (http://ckeditor.com/addon/embed) dialog.

## CKEditor 4.5.6

New Features:

* Introduced the (http://docs.ckeditor.com/#!/api/CKEDITOR.tools-method-setCookie) methods for accessing cookies.
* Introduced the (http://ckeditor.com/addon/filetools) plugins during file uploads. The server-side upload handlers may check it and use it to additionally secure the communication.

Other Changes:

* Updated (http://ckeditor.com/addon/scayt) (Spell Check As You Type):
	- New features:
		- CKEditor (http://ckeditor.com/addon/language) plugin support.
		- CKEditor (http://ckeditor.com/addon/placeholder) plugin support.
		- (http://sdk.ckeditor.com/samples/fileupload.html) support.
		- **Experimental** (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-grayt_autoStartup) (Grammar As You Type) functionality.
	- Fixed issues:
		* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/98): SCAYT affects dialog double-click. Fixed in SCAYT core.
		* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/102): SCAYT core performance enhancements.
		* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/104): SCAYT's spans leak into the clipboard and after pasting.
		* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/105): A JavaScript error fired in case of multiple instances of CKEditor on one page.
		* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/107): SCAYT should not check non-editable parts of content.
		* (https://github.com/WebSpellChecker/ckeditor-plugin-scayt/issues/108): Latest SCAYT copies the ID of the editor element to the iframe.
		* SCAYT stops working when CKEditor (http://ckeditor.com/addon/undo) not enabled.
		* Issue with pasting SCAYT markup in CKEditor.
		* SCAYT stops working after pressing the *Cancel* button in the WSC dialog.

## CKEditor 4.5.5

Fixed Issues:

* (https://github.com/SamZiemer)!
* (http://ckeditor.com/addon/link) plugin dialog does not display the subject of email links if the subject parameter is not lowercase.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-emailProtection) is set to `encode`.
* (https://github.com/StefanRijnhart)!
* (https://github.com/cyril-sf)!
* (http://dev.ckeditor.com/ticket/13867): Fixed: CKEditor does not work when the `classList` polyfill is used.
* (http://ckeditor.com/addon/link) plugin to link an image.
* (http://dev.ckeditor.com/ticket/13883): Fixed: Copying a table using the context menu strips off styles.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-readOnly) mode.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-readOnly) mode throws an exception.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-drop) event.
* (http://dev.ckeditor.com/ticket/13361): Fixed: Skin images fail when the site path includes parentheses because the `background-image` path needs single quotes around the URL value.
* (http://ckeditor.com/addon/wysiwygarea) plugin is missing.
* (http://dev.ckeditor.com/ticket/13782): Fixed: Unclear log messages.
*  Fixed: Browser window crashes when accessing the `isContentEditable` property of an `<input>` DOM element.

Other Changes:

* (http://dev.ckeditor.com/ticket/13859): Test cases created with `bender.tools.createTestsForEditors` will also receive editor bot as a second parameter.

## CKEditor 4.5.4

New Features:

* (http://dev.ckeditor.com/ticket/13632): Introduce error logging mechanism.
* (http://dev.ckeditor.com/ticket/13730): Switch to the new error logging mechanism.

Fixed Issues:

* (https://github.com/mark-wade)!
* (https://github.com/iliyakostadinov)!
*  Fixed: *Ctrl+A* and then *Backspace* result in an empty `<div>` element.
* (http://dev.ckeditor.com/ticket/13599): Fixed: Cross-editor drag and drop of an inline widget results in error/artifacts.
*  Fixed: Dropping a widget outside the `<body>` element is not handled correctly.
* (http://dev.ckeditor.com/ticket/13533): Fixed: No progress during upload.
* (http://dev.ckeditor.com/ticket/13680): Fixed: The parser should allow the `<h1-6>` element to be a child of the `<summary>` element.
*  Fixed: Drop-downs often hide right after opening them.
* (http://dev.ckeditor.com/ticket/13690): Fixed: Copying content from IE to Chrome adds an extra paragraph.
* (http://dev.ckeditor.com/ticket/13284): Fixed: Cannot drag and drop a widget if the text caret is placed just after the widget instance.
* (http://dev.ckeditor.com/ticket/13516): Fixed: CKEditor removes empty HTML5 anchors without the `name` attribute.
*  Fixed: Problems with rendering samples.

Other Changes:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.env-property-mobile) as deprecated. The reason is that it is no longer clear what "mobile" means.
* (https://github.com/benderjs/benderjs) to 0.4.1.

## CKEditor 4.5.3

New Features:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-fileTools_defaultFileName) option to allow setting a default file name for paste uploads.
* (http://dev.ckeditor.com/ticket/13603): Added support for uploading dropped BMP images.

Fixed Issues:

* (http://ckeditor.com/addon/pastefromword) feature. Fixes also:
  * (http://dev.ckeditor.com/ticket/11215),
  * (http://dev.ckeditor.com/ticket/8780),
  * (http://dev.ckeditor.com/ticket/12762).
*  Fixed: Issues with selecting and editing images.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getSelectedHtml) method returns invalid results for entire content selection.
* (http://dev.ckeditor.com/ticket/13453): Fixed: Drag&drop of entire editor content throws an error.
* (http://dev.ckeditor.com/ticket/13465): Fixed: Error is thrown and the widget is lost on drag&drop if it is the only content of the editor.
* (http://dev.ckeditor.com/ticket/13414): Fixed: Content auto paragraphing in a nested editable despite editor configuration.
* (http://ckeditor.com/addon/autoembed) plugin.
* (http://ckeditor.com/addon/undo) is broken.

Other Changes:

* (https://dev.ckeditor.com/ticket/13637): Several icons were refactored.
* Updated (https://dev.ckeditor.com/ticket/13265)).

## CKEditor 4.5.2

Fixed Issues:

* (http://webxsolution.com/)!
* (https://github.com/colemanw)!
* (http://dev.ckeditor.com/ticket/13422): Fixed: A monospaced font should be used in the `<textarea>` element storing editor configuration in the toolbar configurator.
* (http://dev.ckeditor.com/ticket/13494): Fixed: Error thrown in the toolbar configurator if plugin requirements are not met.
* (http://dev.ckeditor.com/ticket/13409): Fixed: List elements incorrectly merged when pressing *Backspace* or *Delete*.
* (http://dev.ckeditor.com/ticket/13434): Fixed: Dialog state indicator broken in Right–To–Left environments.
* (http://docs.ckeditor.com/#!/guide/dev_acf) is disabled.
*  Fixed: Text is not word-wrapped in the Paste dialog window.
*  Fixed: Content copied from Microsoft Word and other external applications is pasted as a plain text. Removed the `CKEDITOR.plugins.clipboard.isHtmlInExternalDataTransfer` property as the check must be dynamic.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.clipboard.dataTransfer-method-getData) should work consistently in all browsers and should not strip valuable content. Fixed pasting tables from Microsoft Excel on Chrome.
*  Fixed: Binding drag&drop `dataTransfer` does not work if `text` data was set in the meantime.
*  Fixed: One drag&drop operation may affect following ones.
* (http://dev.ckeditor.com/ticket/13184): Fixed: Web page reloaded after a drop on editor UI.
* (http://dev.ckeditor.com/ticket/13129) Fixed: Block widget blurred after a drop followed by an undo.
* (http://dev.ckeditor.com/ticket/13397): Fixed: Drag&drop of a widget inside its nested widget crashes the editor.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getSnapshot) may return a non-string value.
* (http://ckeditor.com/addon/autolink) plugin does not encode double quotes in URLs.
* (http://ckeditor.com/addon/autoembed) plugin ignores encoded characters in URL parameters.
* (http://ckeditor.com/addon/autoembed) plugin when undoing right after pasting a link.
* (http://ckeditor.com/addon/embedbase) plugin.
* (http://dev.ckeditor.com/ticket/9715).
*  Fixed: Loss of text when pasting bulleted lists from Microsoft Word.
*  Fixed: Focus lost when opening the panel.
*  Fixed: "Permission denied" error thrown when loading the editor with developer tools open.
*  Fixed: "Permission denied" error thrown when opening editor dialog windows.
* (http://ckeditor.com/addon/undo) commands after a paste.
*  Fixed: Paste dialog's iframe does not receive focus on show.
*  Fixed: Unable to paste a widget.

Other Changes:

* (http://ckeditor.com/addon/autoembed) plugin.

## CKEditor 4.5.1

Fixed Issues:

* (http://ckeditor.com/addon/uploadimage) plugin should log an error, not throw an error when upload URL is not set.

## CKEditor 4.5

New Features:

* (https://github.com/Undergrounder)!
* (http://dev.ckeditor.com/ticket/13215): Added ability to cancel fetching a resource by the Embed plugins.
* (http://ckeditor.com/addon/embed) dialog to indicate that a resource is being loaded.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.repository).
* (http://dev.ckeditor.com/ticket/13214): Added support for pasting links that convert into embeddable resources on the fly.

Fixed Issues:

* (http://dev.ckeditor.com/ticket/13334): Fixed: Error after nesting widgets and playing with undo/redo.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getSelectedHtml) method throws an error when called in the source mode.
* (http://dev.ckeditor.com/ticket/13158): Fixed: Error after canceling a dialog when creating a widget.
* (http://ckeditor.com/addon/image2) alignment class is not transferred to the widget wrapper.
* (http://ckeditor.com/addon/embedsemantic) does not support widget classes.
* (http://dev.ckeditor.com/ticket/13003): Fixed: Anchors are uploaded when moving them by drag and drop.
* (http://dev.ckeditor.com/ticket/13032): Fixed: When upload is done, notification update should be marked as important.
* (http://ckeditor.com/addon/image) dialog seems to be never used.
* (http://dev.ckeditor.com/ticket/13036): Fixed: Notifications are moved 10px to the right.
*  Fixed: Undo after inline widget drag&drop throws an error.
* (http://docs.ckeditor.com/#!/guide/dev_acf).
* (http://dev.ckeditor.com/ticket/13140): Fixed: Error thrown when dropping a block widget right after itself.
*  Fixed: Errors on drag&drop of embed widgets.
* (http://ckeditor.com/addon/image2) causes a page reload.
* (http://dev.ckeditor.com/ticket/13080): Fixed: Ugly notification shown when the response contains HTML content.
*  Fixed: Anchors are duplicated on drag&drop in specific locations.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.tools-method-htmlDecode) methods.
*  Fixed: Copy&paste and drag&drop lists from Microsoft Word.
* (http://dev.ckeditor.com/ticket/13128): Fixed: Various issues with cloning element IDs:
  * Fixed the default behavior of (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.range-method-extractContents) methods which now clone IDs similarly to their native counterparts.
  * Added `cloneId` arguments to the above methods, (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-breakParent). Mind the default values and special behavior in the `extractContents()` method!
  * Fixed issues where IDs were lost on copy&paste and drag&drop.
* Toolbar configurators:
  * (http://dev.ckeditor.com/ticket/13185): Fixed: Wrong position of the suggestion box if there is not enough space below the caret.
  * (http://dev.ckeditor.com/ticket/13138): Fixed: The "Toggle empty elements" button label is unclear.
  * (http://dev.ckeditor.com/ticket/13136): Fixed: Autocompleter is far too intrusive.
  * (http://dev.ckeditor.com/ticket/13133): Fixed: Tab leaves the editor.
  * (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-removeButtons) is ignored by the advanced toolbar configurator.

Other Changes:

* (http://ckeditor.com/addon/kama)) with external web page style sheets.
* Toolbar configurators:
  * (http://dev.ckeditor.com/ticket/13147): Added buttons to the sticky toolbar.
  * (http://dev.ckeditor.com/ticket/13207): Used modal window to display toolbar configurator help.
* (http://docs.ckeditor.com/#!/guide/dev_browsers) guide.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.fileTools.uploadRepository) and changed all related properties.
* (http://dev.ckeditor.com/ticket/13279): Reviewed CSS vendor prefixes.
* (http://ckeditor.com/addon/image) plugin.

## CKEditor 4.5 Beta

New Features:

* Clipboard (copy&paste, drag&drop) and file uploading features and improvements ((http://dev.ckeditor.com/ticket/11437)).

  * Major features:
    * Support for dropping and pasting files into the editor was introduced. Through a set of new facades for native APIs it is now possible to easily intercept and process inserted files.
    * (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-uploadUrl) options, etc.
    * (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.notificationAggregator) to show progress and success or error.
    * All drag and drop operations were integrated with the editor. All dropped content is passed through the (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-dragend).
    * The (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-paste) event.
    * Switched from the pastebin to using the native clipboard access whenever possible. This solved many issues related to pastebin such as unnecessary scrolling or data loss. Additionally, on copy and cut from the editor the clipboard data is set. Therefore, on paste the editor has access to clean data, undisturbed by the browsers.
    * Drag and drop of inline and block widgets was integrated with the standard clipboard APIs. By listening to drag events you will thus be notified about widgets, too. This opens a possibility to filter pasted and dropped widgets.
    * The (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-insertHtml) method now accepts `range` as an additional parameter.
    * (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-pasteFilter) was introduced. The filter is by default turned to `'semantic-content'` on Webkit and Blink for all pasted content coming from external sources because of the low quality of HTML that these engines put into the clipboard. Internal and cross-editor paste is safe due to the change explained in the previous point.

  * Other changes and related fixes:
    * (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getSelectedHtml) is used to get selected HTML as in the normal case. Thanks to that styles applied to inline widgets are not lost.
    * (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-paste) event.
    *  Fixed: Editor scrolls on paste.
    *  Fixed: Pasting causes undesirable scrolling.
    *  Fixed: Pasting content scrolls the document.
    * (http://dev.ckeditor.com/ticket/12613): Show the user that they can not drop on editor UI (toolbar, bottom bar).
    *  Fixed: Formatting disappears when pasting content into cells.
    * (http://dev.ckeditor.com/ticket/12914): Fixed: Copy/Paste of table broken in `div`-based editor.

  * Browser support.<br>Browser support for related features varies significantly (see http://caniuse.com/clipboard).
    * File APIs needed to operate and file upload is not supported in Internet Explorer 9 and below.
    * Only Chrome and Safari on Mac OS support setting custom data items in the clipboard, so currently it is possible to recognize the origin of the copied content in these browsers only. All drag and drop operations can be identified thanks to the new Data Transfer facade.
    * No Internet Explorer browser supports the standard clipboard API which results in small glitches like where only plain text can be dropped from outside the editor. Thanks to the new Data Transfer facade, internal and cross-editor drag and drop supports the full range of data.
    * Direct access to clipboard could only be implemented in Chrome, Safari on Mac OS, Opera and Firefox. In other browsers the pastebin must still be used.

* (http://dev.ckeditor.com/ticket/12875): Samples and toolbar configuration tools.
  * The old set of samples shipped with every CKEditor package was replaced with a shiny new single-page sample. This change concluded a long term plan which started from introducing the (http://docs.ckeditor.com/#!/guide/dev_features) section in the documentation which essentially redefined the old samples.
  * Toolbar configurators with live previews were introduced. They will be shipped with every CKEditor package and are meant to help in configuring toolbar layouts.

* (http://docs.ckeditor.com/#!/guide/dev_media_embed) article.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.nestedEditable.definition-property-allowedContent) is defined precisely, starting from CKEditor 4.5 some widget buttons may become enabled. This feature is not supported in IE8. Included issues:
  * (http://dev.ckeditor.com/ticket/12018): Fixed and reviewed: Nested widgets garbage collection.
  *  Fixed: Outline is extended to the left by unpositioned drag handlers.
  * (http://dev.ckeditor.com/ticket/12006): Fixed: Drag and drop of nested block widgets.
  * (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-insertHtml) method. Fixes pasting a widget with a nested editable inside another widget's nested editable.

* Notification system:
  * (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.notification).
  * (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.notification) which simplifies displaying progress of many concurrent tasks.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-extractSelectedHtml).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.definition-property-upcastPriority) property which gives more control over widget upcasting order to the widget author.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-readOnly) mode when the `<textarea>` element has a `readonly` attribute.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-resize) passes the current dimensions in its data.
* (http://ckeditor.com/addon/image2).
* (http://ckeditor.com/addon/image2) resizer.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget) functions (see the static methods).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editable-method-insertHtmlIntoRange) method.
* (http://github.com/InvisibleBacon)!
* (https://github.com/edithkk)!
* (https://github.com/tiemevanveen)!
* (https://github.com/sbusse)!

Changes:

* (http://blogs.windows.com/bloggingwindows/2015/03/30/introducing-project-spartan-the-new-browser-built-for-windows-10/) browser compatibility. Full compatibility will be introduced later, because at the moment Spartan is still too unstable to be used for tests and we see many changes from version to version.
* (http://ckeditor.com/addon/mathjax) plugin now.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editable-method-insertElementIntoRange) method directly for the pre 4.5 behavior of `editable.insertElement()`.
* (http://ckeditor.com/addon/notification) is loaded, the notification system is used automatically. Otherwise, the native `alert()` is displayed.
* (https://github.com/kevinisagit)!
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-hasClass) methods. Note: The previous implementation allowed passing multiple classes to `addClass()` although it was only a side effect of that implementation. The new implementation does not allow this.
* (http://dev.ckeditor.com/ticket/11856): The jQuery adapter throws a meaningful error if CKEditor or jQuery are not loaded.

Fixed issues:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.range-method-cloneContents) should not change the DOM in order not to affect selection.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-getChild) should not modify a passed array.
*  Fixed: Incorrect result of Select All and *Backspace* or *Delete*.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.range-method-fixBlock) method due to quirky Firefox behavior.
*  Fixed: Colons are prepended to HTML5 element names when cloning them.

## CKEditor 4.4.8

**Security Updates:**

* Fixed XSS vulnerability in the HTML parser reported by (https://twitter.com/iAmPr3m).

	Issue summary: It was possible to execute XSS inside CKEditor after persuading the victim to: (i) switch CKEditor to source mode, then (ii) paste a specially crafted HTML code, prepared by the attacker, into the opened CKEditor source area, and (iii) switch back to WYSIWYG mode.

**An upgrade is highly recommended!**

Fixed Issues:

* (https://github.com/mizafish)!
* (https://github.com/jcttrll)!
* (https://github.com/benkiefer)!
* (https://github.com/asmforce)!
* (https://github.com/asmforce)!
* (https://github.com/FlorianLudwig)!
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-appendText) method does not work properly for empty elements.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.htmlDataProcessor) can process `foo:href` attributes.
* (https://github.com/andrewstucki)!
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getData) parameter documentation.
* (http://dev.ckeditor.com/ticket/11982): Fixed: Bullet added in a wrong position after the *Enter* key is pressed in a nested list.
* (http://www.w3.org/TR/2013/WD-wai-aria-practices-20130307/#tabpanel).
* (http://ckeditor.com/addon/basicstyles) were configured to use classes.
* (http://dev.ckeditor.com/ticket/12729): Fixed: Incorrect structure created when merging a block into a list item on *Backspace* and *Delete*.
*  Fixed: No more line breaks in source view since Firefox 36.
* (http://ckeditor.com/addon/wysiwygarea) plugin.
* (http://dev.ckeditor.com/ticket/9086): Fixed: Invalid ARIA property used on paste area `<iframe>`.
* (http://dev.ckeditor.com/ticket/13164): Fixed: Error when inserting a hidden field.
* (http://ckeditor.com/addon/lineutils) positioning when `<body>` has a margin.
* (https://dev.ckeditor.com/ticket/12847)).
* (http://docs.ckeditor.com/#!/guide/dev_readonly).

Other Changes:

* (https://github.com/benderjs/benderjs) `0.2.3`.
* (http://ckeditor.com/addon/mathjax) plugin tests.
* (https://github.com/mizafish)!


## CKEditor 4.4.7

Fixed Issues:

* (https://github.com/Paul-Martin)!
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-tabSpaces) configuration option value was greater than zero.
* (https://github.com/vita10gy)!
* (https://github.com/thecatontheflat)!
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-fillEmptyBlocks) should only apply when outputting data.
* (http://ckeditor.com/addon/pastefromword) filter is executed for every paste after using the button.
*  Fixed: Multi-byte Japanese characters entry not working properly after *Shift+Enter*.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-uiColor) is defined.
*  Fixed: Opening a drop-down for a specific selection when the editor is maximized results in incorrect drop-down panel position.
*  Fixed: An error is thrown after focusing the editor.

## CKEditor 4.4.6

**Security Updates:**

* Fixed XSS vulnerability in the HTML parser reported by (https://www.facebook.com/Maaacoooo).

	Issue summary: It was possible to execute XSS inside CKEditor after persuading the victim to: (i) switch CKEditor to source mode, then (ii) paste a specially crafted HTML code, prepared by the attacker, into the opened CKEditor source area, and (iii) switch back to WYSIWYG mode.

**An upgrade is highly recommended!**

New Features:

* (http://docs.ckeditor.com/#!/guide/dev_allowed_content_rules-section-string-format).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dtd).

Fixed Issues:

* (https://github.com/shaohua)!
* (https://github.com/timselier)!
* (http://dev.ckeditor.com/ticket/12491#comment:4).
* (http://dev.ckeditor.com/ticket/12621): Fixed: Cannot remove inline styles (bold, italic, etc.) in empty lines.
* (http://ckeditor.com/addon/newpage) button is clicked. This patch significantly simplified the way how the initial selection (a selection after the content of the editable is overwritten) is being fixed. That might have fixed many related scenarios in all browsers.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-blur) event is not fired on first blur after initializing the inline editor on an already focused element.
* (http://ckeditor.com/addon/basicstyles) button tooltip spelling.
* (http://ckeditor.com/addon/docprops) dialog window is always disabled.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-change) event fired on first navigation key press after typing.
* (http://dev.ckeditor.com/ticket/12141): Fixed: List items are lost when indenting a list item with content wrapped with a block element.
* (http://dev.ckeditor.com/ticket/12515): Fixed: Cursor is in the wrong position when undoing after adding an image and typing some text.
*  Fixed: DOM is changed outside the editor area in a certain case.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.style) and fixed two minor issues.
* (http://ckeditor.com/addon/font) style should not lead to nesting it in the previous style element.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-magicline_everywhere) configuration option.


## CKEditor 4.4.5

New Features:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.node-method-getAscendant).

Fixed Issues:

*  Fixed: *Enter* key moved cursor to a strange position.
* (https://github.com/Remiremi)!
* (https://github.com/tandraschko)!
* (https://github.com/naoki-fujikawa)!
* (https://github.com/Axinet)!
* (http://dev.ckeditor.com/ticket/12162): Fixed: Auto paragraphing and *Enter* key in nested editables.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-autoParagraph) as deprecated.
* (http://ckeditor.com/addon/elementspath) as "code snippet" (translatable).
* (http://ckeditor.com/addon/removeformat) should also remove `<cite>` elements.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.filter-static-property-instances) on editor destroy.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-title).
* (http://ckeditor.com/addon/colorbutton) button menu.
* (http://ckeditor.com/addon/pagebreak) used directly in the editable breaks the editor.
* (http://dev.ckeditor.com/ticket/12354): Fixed: Various issues in undo manager when holding keys.
*  Fixed: Undo steps are not recorded when changing the caret position by clicking below the body.
* (http://dev.ckeditor.com/ticket/12332): Fixed: Lowered DOM events listeners' priorities in undo manager in order to avoid ambiguity.
*  Fixed: Workaround for Blink bug with `document.title` which breaks updating title in the full HTML mode.
* (http://dev.ckeditor.com/ticket/12338): Fixed: The CKEditor package contains unoptimized images.


## CKEditor 4.4.4

Fixed Issues:

* (https://github.com/CasherWest)!
* (https://github.com/mesmerizero)!
* (https://github.com/mesmerizero)!
* (http://dev.ckeditor.com/ticket/11739): Fixed: `keypress` listeners should not be used in the undo manager. A complete rewrite of keyboard handling in the undo manager was made. Numerous smaller issues were fixed, among others:
  * (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-change) event.
  * (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-change) event is fired when pressing Arrow keys.
  * (http://ckeditor.com/addon/undo) plugin.
* (http://ckeditor.com/addon/magicline) icon in Right-To-Left environments.
*  Fixed: CKEditor `paste` event is not fired when pasting with *Shift+Ins*.
* (http://dev.ckeditor.com/ticket/12111): Fixed: Linked image attributes are not read when opening the image dialog window by doubleclicking.
*  Fixed: Prevented "Unspecified Error" thrown in various cases when IE8-9 does not allow access to `document.activeElement`.
* (http://dev.ckeditor.com/ticket/12273): Fixed: Applying block style in a description list breaks it.
* (http://dev.ckeditor.com/ticket/12218): Fixed: Minor syntax issue in CSS files.
*  Fixed: Iterator does not return the block if the selection is located at the end of it.
*  Fixed: Error thrown when moving the mouse over focused editor's scrollbar.
* (http://dev.ckeditor.com/ticket/12215): Fixed: Basepath resolution does not recognize semicolon as a query separator.
* (http://ckeditor.com/addon/removeformat) does not work on widgets.
*  Fixed: Clicking below `<body>` in Compatibility Mode will no longer reset selection to the first line.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-title).
* (http://ckeditor.com/addon/scayt) enabled, cursor moves to the beginning of the first highlighted, misspelled word after typing or pasting into the editor.
* (http://ckeditor.com/addon/scayt) and trying to add a new image.


Other Changes:

* (http://dev.ckeditor.com/ticket/12296): Merged `benderjs-ckeditor` into the main CKEditor repository.

## CKEditor 4.4.3

**Security Updates:**

* Fixed XSS vulnerability in the Preview plugin reported by Mario Heiderich of (https://cure53.de/).

**An upgrade is highly recommended!**

New Features:

* (http://dev.ckeditor.com/ticket/12164): Added the "Justify" option to the "Horizontal Alignment" drop-down in the Table Cell Properties dialog window.

Fixed Issues:

* (https://github.com/mesmerizero)!
* (https://github.com/noam-si)!
* (http://dev.ckeditor.com/ticket/12140): Fixed: Double-clicking linked widgets opens two dialog windows.
* (http://dev.ckeditor.com/ticket/12132): Fixed: Image is inserted with `width` and `height` styles even when they are not allowed.
* (https://connect.microsoft.com/IE/feedback/details/742593/please-respect-execcommand-enableobjectresizing-in-contenteditable-elements).
* (http://ckeditor.com/addon/a11yhelp) plugin is not available.
* (http://dev.ckeditor.com/ticket/9186): Fixed: In HTML5 `<meta>` tags should be allowed everywhere, including inside the `<body>` element.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-fillEmptyBlocks) not working properly if a function is specified.

## CKEditor 4.4.2

Important Notes:

* The CKEditor testing environment is now publicly available. Read more about how to set up the environment and execute tests in the (http://docs.ckeditor.com/#!/guide/dev_tests) guide.
	Please note that the (https://github.com/ckeditor/ckeditor-dev/).

New Features:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-setData) method from recording undo snapshots.

Fixed Issues:

* (https://github.com/danyaPostfactum)!
* (https://github.com/dan-james-deeson)!
* (http://docs.ckeditor.com/#!/guide/dev_jquery) configuration.
* (http://dev.ckeditor.com/ticket/10867): Fixed: Issue with setting encoded URI as image link.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.repository-method-getByElement) method was improved.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.nestedEditable-method-setData).
* (http://dev.ckeditor.com/ticket/12022): Fixed: Outer widget's drag handler is not created at all if it has any nested widgets inside.
*  Fixed: The caret should be scrolled into view on *Backspace* and *Delete* (covers only the merging blocks case).
*  Fixed: No widget entries in the context menu on widget right-click.
* (http://ckeditor.com/addon/image2) dialog window are not translated.
*  Fixed: `<span>` elements created when joining adjacent elements (non-collapsed selection).
* (http://ckeditor.com/addon/magicline) plugin.
* (http://dev.ckeditor.com/ticket/11387): Fixed: `role="radiogroup"` should be applied only to radio inputs' container.
*  Fixed: Errors when trying to select an empty table cell.
*  Fixed: *Shift+Enter* in lists produces two line breaks.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-setText) method should not trigger the layout engine.
* (http://ckeditor.com/addon/flash) plugin omits the `allowFullScreen` parameter in the editor data if set to `true`.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-baseHref) into account when updating image dimensions.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-checkDirty) method value after focusing or blurring a widget.
* (https://github.com/ckeditor/ckbuilder) when using the `/dev/builder/build.sh` script.
* (http://ckeditor.com/addon/forms) plugin should not change a core method.
*  Fixed: `IndexSizeError` thrown when pasting into a non-empty selection anchored in one text node.

## CKEditor 4.4.1

New Features:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-linkJavaScriptLinksAllowed) anchor tags with JavaScript code in the `href` attribute.

Fixed Issues:

*  Fixed: Span elements created while joining adjacent elements. **Note:** This patch only covers cases when *Backspace* or *Delete* is pressed on a collapsed (empty) selection. The remaining case, with a non-empty selection, will be fixed in the next release.
* (https://github.com/artygus)!
* (https://github.com/akashmohapatra)!
* (http://ckeditor.com/addon/codesnippet) does not decode HTML entities when loading code from the `<code>` element.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-protectedSource) was not working in the `<title>` element.
* (http://ckeditor.com/addon/codesnippet) sample.
*  Fixed: Infinite loop when content includes not closed attributes.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-insertElement) throwing an exception when there was no selection in the editor.
* (http://ckeditor.com/addon/image2) widget.
* (http://ckeditor.com/addon/tableresize) sets invalid column width.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-removeClass).
* (http://ckeditor.com/addon/image2)).
* (http://ckeditor.com/addon/image2) context menu.
*  Fixed: The caret jumps out of the editable area when resizing the editor in the source mode.
*  Fixed: Editing anchors by double-click is broken in some cases.
* (http://ckeditor.com/addon/tableresize) throws an error over scrollbar.
* (http://ckeditor.com/addon/codesnippet) dialog window.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.htmlParser.filter) rules are not applied inside elements with the `contenteditable` attribute set to `true`.
* (http://dev.ckeditor.com/ticket/11798): Fixed: Inserting a non-editable element inside a table cell breaks the table.
* (http://dev.ckeditor.com/ticket/11793): Fixed: Drop-down is not "on" when clicking it while the editor is blurred.
* (http://dev.ckeditor.com/ticket/11850): Fixed: Fake objects with the `contenteditable` attribute set to `false` are not downcasted properly.
* (http://dev.ckeditor.com/ticket/11811): Fixed: Widget's data is not encoded correctly when passed to an attribute.
* (http://ckeditor.com/addon/mathjax) plugin.
*  Fixed: Linked image has a default thick border.

Other Changes:

* (http://dev.ckeditor.com/ticket/11807): Updated jQuery version used in the sample to 1.11.0 and tested CKEditor jQuery Adapter with version 1.11.0 and 2.1.0.
* (http://dev.ckeditor.com/ticket/9504): Stopped using deprecated `attribute.specified` in all browsers except Internet Explorer.
* (http://dev.ckeditor.com/ticket/11809): Changed tab size in `<pre>` to 4 spaces.

## CKEditor 4.4

**Important Notes:**

* Marked the (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-beforePaste) event as deprecated.
* The default class of captioned images has changed to `image` (was: `caption`). Please note that once edited in CKEditor 4.4+, all existing images of the `caption` class (`<figure class="caption">`) will be (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-image2_captionedClass) option is set to `caption`. For backward compatibility (i.e. when upgrading), it is highly recommended to use this setting, which also helps prevent CSS conflicts, etc. This does not apply to new CKEditor integrations.
* Widgets without defined buttons are no longer registered automatically to the (http://docs.ckeditor.com/#!/api/CKEDITOR.feature-property-requiredContent) properties for it manually, because the editor will not be able to find them.
* The (http://dev.ckeditor.com/ticket/11665)).
* Since CKEditor 4.4 the editor instance should be passed to (http://docs.ckeditor.com/#!/api/CKEDITOR.style) will work even when the editor instance is not provided.

New Features:

* (http://docs.ckeditor.com/#!/guide/dev_styles-section-widget-styles) section of the "Syles Drop-down" guide. Note that by default, widgets support only classes and no other attributes or styles. Related changes and features:
  * Introduced the (http://docs.ckeditor.com/#!/api/CKEDITOR.style-static-method-addCustomHandler) method for registering custom style handlers.
  * The (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-removeStyle) methods. Backward compatibility was preserved, but from CKEditor 4.4 it is highly recommended to pass an editor instead of a document to these methods.
  * Many new methods and properties were introduced in the (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget-method-checkStyleActive).
  * Integration with the (http://docs.ckeditor.com/#!/api/CKEDITOR.filter.allowedContentRules).
* (http://ckeditor.com/addon/image2) plugin:
  * Introduced the (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-image2_captionedClass) option to configure the class of captioned images.
  * Introduced the (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-image2_alignClasses) option to configure the way images are aligned with CSS classes.
  If this setting is defined, the editor produces classes instead of inline styles for aligned images.
  * Default image caption can be translated (customized) with the `editor.lang.image2.captionPlaceholder` string.
* (http://ckeditor.com/addon/image2) plugin: It is now possible to add a link to any image type.
* (http://docs.ckeditor.com/#!/guide/dev_allowed_content_rules) format.
* (http://docs.ckeditor.com/#!/guide/dev_advanced_content_filter).
* (http://qbnz.com/highlighter/) library.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.filter-method-addElementCallback)).
* (http://docs.ckeditor.com/#!/guide/plugin_sdk_styles).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.tools-method-htmlDecode) method for decoding HTML entities.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.tools-property-transparentImageData) property which contains transparent image data to be used in CSS or as image source.

Other Changes:

* (http://ckeditor.com/addon/fakeobjects).
* (http://dev.ckeditor.com/ticket/11422): Removed Firefox 3.x, Internet Explorer 6 and Opera 12.x leftovers in code.
* (http://dev.ckeditor.com/ticket/5217): Setting data (including switching between modes) creates a new undo snapshot. Besides that:
  * Introduced the (http://docs.ckeditor.com/#!/api/CKEDITOR.editable-property-status) property.
  * Introduced a new `forceUpdate` option for the (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-lockSnapshot) event.
  * Fixed: Selection not being unlocked in inline editor after setting data ((http://dev.ckeditor.com/ticket/11500)).
* The (http://ckeditor.com/addon/wsc) plugin was updated to the latest version.

Fixed Issues:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-removeStyle) should result in a paragraph and not a div.
* (http://dev.ckeditor.com/ticket/11727): Fixed: The editor tries to select a non-editable image which was clicked.

## CKEditor 4.3.5

New Features:

* Added new translation: Tatar.

Fixed Issues:

* (http://dev.ckeditor.com/ticket/11677): Fixed: Undo/Redo keystrokes are blocked in the source mode.
* (http://ckeditor.com/addon/colordialog) plugin to work.

## CKEditor 4.3.4

Fixed Issues:

* (http://ckeditor.com/addon/preview) using the keyboard.
* (http://ckeditor.com/addon/placeholder) will no longer be upcasted in parents not accepting `<span>` elements.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.element-method-getName) cache.
* (http://dev.ckeditor.com/ticket/11574): Fixed: *Backspace* destroying the DOM structure if an inline editable is placed in a list item.
* (http://ckeditor.com/addon/tableresize) attaches to tables outside the editable.
* (http://dev.ckeditor.com/ticket/8216): Fixed: `{cke_protected_1}` appearing in data in various cases where HTML comments are placed next to `"` or `'`.
* (http://dev.ckeditor.com/ticket/11635): Fixed: Some attributes are not protected before the content is passed through the fix bin.
*  Fixed: Table content is lost when some extra markup is inside the table.
* (http://dev.ckeditor.com/ticket/11641): Fixed: Switching between modes in the classic editor removes content styles for the inline editor.
* (http://ckeditor.com/addon/stylescombo) drop-down list is not enabled on selection change.

## CKEditor 4.3.3

Fixed Issues:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.selection-property-root).
*  Fixed: Various issues with scrolling and selection when focusing widgets.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-checkDirty) method.
* (http://ckeditor.com/addon/pagebreak).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-execCommand) behavior.
* (http://dev.ckeditor.com/ticket/11438): Splitting table cells vertically is no longer changing table structure.
* (http://ckeditor.com/addon/about) dialog window now open in a new browser window or tab.
* (http://ckeditor.com/addon/menubutton) panel not showing in the source mode.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget-event-doubleclick) event is not canceled anymore after editing was triggered.
* (http://ckeditor.com/addon/image2) dialog window.
* (http://ckeditor.com/addon/link) plugin.
*  Fixed: Error when deleting a table row.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.htmlDataProcessor) discovering protected attributes within other attributes' values.
* (http://dev.ckeditor.com/ticket/11533): Widgets: Avoid recurring upcasts if the DOM structure was modified during an upcast.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.domObject-method-removeAllListeners) method does not remove custom listeners completely.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.selection-method-getRanges) method does not override cached ranges when used with the `onlyEditables` argument.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.xml) now work in IE10+.
*  Fixed: Blurry toolbar icons when Right-to-Left UI language is set.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-fullPage) is set to `true`, entities are not encoded in editor output.
* (http://docs.ckeditor.com/#!/guide/dev_advanced_content_filter).
* (http://dev.ckeditor.com/ticket/11439): Fixed: Properties get cloned in the Cell Properties dialog window if multiple cells are selected.

## CKEditor 4.3.2

Fixed Issues:

* (http://dev.ckeditor.com/ticket/11331): A menu button will have a changed label when selected instead of using the `aria-pressed` attribute.
* (http://dev.ckeditor.com/ticket/11177): Widget drag handler improvements:
  * (http://dev.ckeditor.com/ticket/11176): Fixed: Initial position is not updated when the widget data object is empty.
  * (http://dev.ckeditor.com/ticket/11001): Fixed: Multiple synchronous layout recalculations are caused by initial drag handler positioning causing performance issues.
  * (http://dev.ckeditor.com/ticket/11161): Fixed: Drag handler is not repositioned in various situations.
  * (http://dev.ckeditor.com/ticket/11281): Fixed: Drag handler and mask are duplicated after widget reinitialization.
* (http://ckeditor.com/addon/image2) resizer in the inline editor.
* (http://dev.ckeditor.com/ticket/11102): `CKEDITOR.template` improvements:
  * (http://dev.ckeditor.com/ticket/11102): Added newline character support.
  * (http://dev.ckeditor.com/ticket/11216): Added "\\'" substring support.
*  Fixed: High Contrast mode is enabled when the editor is loaded in a hidden iframe.
* (http://docs.ckeditor.com/#!/api/CKEDITOR-method-getUrl).
* (http://ckeditor.com/addon/autogrow) plugin performance when dealing with very big tables.
* (http://ckeditor.com/addon/sourcedialog) plugin.
* (http://ckeditor.com/addon/pagebreak) becomes editable if pasted.
* (http://dev.ckeditor.com/ticket/11126): Fixed: Native Undo executed once the bottom of the snapshot stack is reached.
* (http://ckeditor.com/addon/divarea): Fixed: Error thrown when switching to source mode if the selection was in widget's nested editable.
* (http://ckeditor.com/addon/divarea): Fixed: Elements Path is not cleared after switching to source mode.
* (http://dev.ckeditor.com/ticket/10778): Fixed a bug with range enlargement. The range no longer expands to visible whitespace.
*  Fixed: Preview window switches Internet Explorer to Quirks Mode.
*  Fixed: JavaScript code displayed in preview window's URL bar.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.repository-method-addUpcastCallback) method that allows to block upcasting given element to a widget.
* (http://mootools.net) library.
*  Fixed: Anchors are not draggable.
* (http://dev.ckeditor.com/ticket/9696)).
*  Fixed: Broken replacement of text while pasting into `div`-based editor.
* (http://ckeditor.com/addon/showblocks) plugin.
* (http://dev.ckeditor.com/ticket/11021): Fixed: An error thrown when selecting entire editable contents while fake selection is on.
*  Re-enable inline widgets drag&drop in Internet Explorer 8.
* (http://dev.ckeditor.com/ticket/11372): Widgets: Special characters encoded twice in nested editables.
* (http://dev.ckeditor.com/ticket/10068): Fixed: Support for protocol-relative URLs.
* (http://ckeditor.com/addon/image2): A `<div>` element with `text-align: center` and an image inside is not recognised correctly.
* (http://ckeditor.com/addon/a11yhelp): Allowed additional keyboard button labels to be translated in the dialog window.

## CKEditor 4.3.1

**Important Notes:**

* To match the naming convention, the `language` button is now `Language` ((http://dev.ckeditor.com/ticket/11201)).
* (http://dev.ckeditor.com/ticket/11222)).

Fixed Issues:

* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.repository-event-checkWidgets) event, so from CKEditor 4.3.1 it is preferred to use the method rather than fire the event.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.repository-method-checkWidgets) method.
* (http://ckeditor.com/addon/mathjax) widget with a placeholder.
* (http://ckeditor.com/addon/language) plugin drop-down menu.
* (http://dev.ckeditor.com/ticket/11075): With drop-down menu button focused, pressing the *Down Arrow* key will now open the menu and focus its first option.
* (http://ckeditor.com/addon/filebrowser) plugin cannot be removed from the editor.
* (http://ckeditor.com/addon/image2): Fixed buggy discovery of image dimensions.
* (http://dev.ckeditor.com/ticket/11101): Drop-down lists no longer break when given double quotes.
* (http://ckeditor.com/addon/image2): Empty undo step recorded when resizing the image.
* (http://ckeditor.com/addon/image2): Widget has paragraph wrapper when de-captioning unaligned image.
* (http://dev.ckeditor.com/ticket/11198): Widgets: Drag handler is not fully visible when an inline widget is in a heading.
*  Fixed: Caret is lost after drag and drop of an inline widget.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.env-property-quirks) for more details.
* (http://ckeditor.com/addon/image2) looks nicer.
* (http://ckeditor.com/addon/bbcode) mode.
* (http://dev.ckeditor.com/ticket/10890): Fixed: Error thrown when pressing the *Delete* key in a list item.
*  Fixed: *Delete* pressed on a selected image causes the browser to go back.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-insertElement) method does not insert the element into every range of a selection any more.
* (http://dev.ckeditor.com/ticket/11042): Fixed: Selection made on an element containing a non-editable element was not auto faked.
* (http://dev.ckeditor.com/ticket/11125): Fixed: Keyboard navigation through menu and drop-down items will now cycle.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-applyStyle) method removes attributes from nested elements.
* (http://ckeditor.com/addon/tableresize) plugin for inline editors.
* (http://dev.ckeditor.com/ticket/11237): Fixed: Table border attribute value is deleted when pasting content from Microsoft Word.
* (http://dev.ckeditor.com/ticket/11250): Fixed: HTML entities inside the `<textarea>` element are not encoded.
* (http://dev.ckeditor.com/ticket/11260): Fixed: Initially disabled buttons are not read by JAWS as disabled.
* (http://ckeditor.com/addon/widget) to fix drag and drop.

## CKEditor 4.3

New Features:

* (http://dev.ckeditor.com/ticket/10612): Internet Explorer 11 support.
* (http://ckeditor.com/addon/elementspath) plugin.
* (http://dev.ckeditor.com/ticket/10886): Widgets: Added tooltip to the drag handle.
* (http://ckeditor.com/addon/lineutils) plugin.
* (http://dev.ckeditor.com/ticket/10936): Widget System changes for easier integration with other dialog systems.
* (http://ckeditor.com/addon/image2): Added file browser integration.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget.definition-property-draggable) option to disable drag and drop support for widgets.
* (http://ckeditor.com/addon/mathjax) widget improvements:
  * loading indicator ((http://dev.ckeditor.com/ticket/10948)),
  * applying paragraph changes (like font color change) to iframe ((http://dev.ckeditor.com/ticket/10841)),
  * Firefox and IE9 clipboard fixes ((http://dev.ckeditor.com/ticket/10857)),
  * fixing same origin policy issue ((http://dev.ckeditor.com/ticket/10840)),
  * fixing undo bugs ((http://dev.ckeditor.com/ticket/10930)),
  * fixing other minor bugs.
* (http://ckeditor.com/addon/placeholder) plugin was rewritten as a widget.
* (http://dev.ckeditor.com/ticket/10822): Added styles system integration with non-editable elements (for example widgets) and their nested editables. Styles cannot change non-editable content and are applied in nested editable only if allowed by its type and content filter.
* (http://ckeditor.com/addon/language) plugin fixes: Added active language highlighting, added an option to remove the language.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-dialog_noConfirmCancel) configuration option that eliminates the need to confirm closing of a dialog window when the user changed any of its fields.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-activeFilter).
* (http://ckeditor.com/addon/bbcode) sample from GIF to PNG.

Fixed Issues:

* (http://ckeditor.com/addon/image2): Merged `image2inline` and `image2block` into one `image2` widget.
* (http://ckeditor.com/addon/image2): Improved visibility of the resize handle.
* (http://ckeditor.com/addon/image2): Preserve custom mouse cursor while resizing the image.
* (http://ckeditor.com/addon/image2): hovering the image causes it to change.
* (http://ckeditor.com/addon/image2) dialog window.
* (http://ckeditor.com/addon/image2) dialog window.
* (http://dev.ckeditor.com/ticket/10881): Various improvements to *Enter* key behavior in nested editables.
* (http://ckeditor.com/addon/removeformat) should not leak from a nested editable.
* (http://ckeditor.com/addon/wsc) fails to apply changes if a nested editable was focused.
* (http://ckeditor.com/addon/wsc) blocks typing in nested editables.
* (http://ckeditor.com/addon/placeholder) sample.
* (http://dev.ckeditor.com/ticket/10870): The `paste` command is no longer being disabled when the clipboard is empty.
* (http://dev.ckeditor.com/ticket/10854): Fixed: Firefox prepends `<br>` to `<body>`, so it is stripped by the HTML data processor.
* (http://ckeditor.com/addon/link) plugin does not work with non-editable content.
* (http://ckeditor.com/addon/magicline) integration with the Widget System.
* (http://dev.ckeditor.com/ticket/10865): Improved hiding copybin, so copying widgets works smoothly.
* (http://dev.ckeditor.com/ticket/11066): Widget's private parts use CSS reset.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-contentDomInvalidated) event.
* (http://ckeditor.com/addon/forms) plugin.
* (http://dev.ckeditor.com/ticket/10911): Fixed: Browser *Alt* hotkeys will no longer be blocked while a widget is focused.
* (http://dev.ckeditor.com/ticket/11082): Fixed: Selected widget is not copied or cut when using toolbar buttons or context menu.
* (http://dev.ckeditor.com/ticket/11083): Fixed list and div element application to block widgets.
* (http://dev.ckeditor.com/ticket/10887): Internet Explorer 8 compatibility issues related to the Widget System.
* (http://dev.ckeditor.com/ticket/11074): Temporarily disabled inline widget drag and drop, because of seriously buggy native `range#moveToPoint` method.
* (http://dev.ckeditor.com/ticket/11098): Fixed: Wrong selection position after undoing widget drag and drop.
* (http://dev.ckeditor.com/ticket/11110): Fixed: IFrame and Flash objects are being incorrectly pasted in certain conditions.
* (http://dev.ckeditor.com/ticket/11129): Page break is lost when loading data.
*  Widget is destroyed after being dragged outside of `<body>`.
* (http://ckeditor.com/addon/divarea).

## CKEditor 4.3 Beta

New Features:

* (http://dev.ckeditor.com/ticket/9764): Widget System.
  * (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.widget).
  * New (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-shiftEnterMode).
  * Dynamic editor settings. Starting from CKEditor 4.3 Beta, *Enter* mode values and (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-enterMode) *Enter* mode values depending on whether this feature works in selection context or globally on editor content.
      * Dynamic *Enter* mode values &ndash; (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-activeShiftEnterMode).
      * Dynamic content filter instances &ndash; (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-activeFilter) property.
  * "Fake" selection was introduced. It makes it possible to virtually select any element when the real selection remains hidden. See the  (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.selection-method-fake) method.
  * Default (http://docs.ckeditor.com/#!/api/CKEDITOR.htmlParser.filter-method-addRules) method.
  * Dozens of new methods were introduced &ndash; most interesting ones:
      * (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.document-method-find),
      * (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.document-method-findOne),
      * (http://docs.ckeditor.com/#!/api/CKEDITOR.editable-method-insertElementIntoRange),
      * (http://docs.ckeditor.com/#!/api/CKEDITOR.dom.range-method-moveToClosestEditablePosition),
      * New methods for (http://docs.ckeditor.com/#!/api/CKEDITOR.htmlParser.element).
* (http://ckeditor.com/addon/image2) plugin that introduces a widget with integrated image captions, an option to center images, and dynamic "click and drag" resizing.
* (http://ckeditor.com/addon/mathjax) plugin that introduces the MathJax widget.
* (http://www.w3.org/TR/UNDERSTANDING-WCAG20/meaning-other-lang-id.html).
* (http://ckeditor.com/addon/smiley).

## CKEditor 4.2.3

Fixed Issues:

* (http://docs.ckeditor.com/#!/guide/dev_jquery) sample directly from file.
*  Fixed: Error thrown while opening the color palette.
*  Fixed: A non-breaking space is created once a character is deleted and a regular space is typed.
* (http://ckeditor.com/addon/magicline).
* (http://dev.ckeditor.com/ticket/11096): Fixed: TypeError: Object has no method 'is'.

## CKEditor 4.2.2

Fixed Issues:

* (http://dev.ckeditor.com/ticket/9314): Fixed: Incorrect error message on closing a dialog window without saving changs.
*  Fixed: Unspecified error when deleting a row.
*  Fixed: Clicking with a mouse inside the editor does not show the caret.
* (http://dev.ckeditor.com/ticket/10912): Prevent default action when content of a non-editable link is clicked.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.resourceManager-method-addExternal) not handling paths including file name specified.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.tools-method-isArray) not working cross frame.
*  Fixed JavaScript error thrown in Compatibility Mode when clicking and/or typing in the editing area.
*  Prevent the browser from crashing when applying the Inline Quotation style.
* (http://dev.ckeditor.com/ticket/10915): Fixed: Invalid CSS filter in the Kama skin.
* (http://ckeditor.com/addon/indentblock) are now included in the build configuration.
* (http://dev.ckeditor.com/ticket/10842).
* (http://dev.ckeditor.com/ticket/10707).
* (http://dev.ckeditor.com/ticket/10704): Fixed a JAWS issue with the Select Color dialog window title not being announced.
* (http://dev.ckeditor.com/ticket/10753): The floating toolbar in inline instances now has a dedicated accessibility label.

## CKEditor 4.2.1

Fixed Issues:

*  Undo fails after 3+ consecutive paste actions with a JavaScript error.
* (http://dev.ckeditor.com/ticket/10689): Save toolbar button saves only the first editor instance.
* (http://dev.ckeditor.com/ticket/10368): Move language reading direction definition (`dir`) from main language file to core.
* (http://dev.ckeditor.com/ticket/9330): Fixed pasting anchors from MS Word.
* (http://dev.ckeditor.com/ticket/8103): Fixed pasting nested lists from MS Word.
*  Pressing the "OK" button will trigger the `onbeforeunload` event in the popup dialog.
* (http://ckeditor.com/addon/sharedspace) is used.
* (http://dev.ckeditor.com/ticket/9654): Problems with Internet Explorer 10 Quirks Mode.
* (http://dev.ckeditor.com/ticket/9816): Floating toolbar does not reposition vertically in several cases.
* (http://dev.ckeditor.com/ticket/10646): Removing a selected sublist or nested table with *Backspace/Delete* removes the parent element.
*  Page is scrolled when opening a drop-down list.
*  Button names are not announced.
* (http://ckeditor.com/addon/wsc) plugin breaks cloning of editor configuration.
* It is now possible to set per instance (http://ckeditor.com/addon/wsc) plugin configuration instead of setting the configuration globally.

## CKEditor 4.2

**Important Notes:**

* Dropped compatibility support for Internet Explorer 7 and Firefox 3.6.

* Both the Basic and the Standard distribution packages will not contain the new (http://ckeditor.com/builder).

New Features:

* (http://ckeditor.com/addon/indentblock).
* (http://dev.ckeditor.com/ticket/8244): Use *(Shift+)Tab* to indent and outdent lists.
* (http://dev.ckeditor.com/ticket/6906).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-title) setting to change the human-readable title of the editor.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-change) event.
* (http://ckeditor.com/addon/moono) added.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-required) event.
* (http://dev.ckeditor.com/ticket/10280): Ability to replace `<textarea>` elements with the inline editor.

Fixed Issues:

* (http://ckeditor.com/addon/list) plugin.
* (http://dev.ckeditor.com/ticket/10370): Inconsistency in data events between framed and inline editors.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-setData).

## CKEditor 4.1.3

New Features:

* Added new translation: Indonesian.

Fixed Issues:

* (http://dev.ckeditor.com/ticket/10644): Fixed a critical bug when pasting plain text in Blink-based browsers.
* (http://ckeditor.com/addon/find) dialog window: rename "Cancel" button to "Close".
* (http://ckeditor.com/addon/moono) skin.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-shiftEnterMode).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.dialog-static-method-addIframe) incorrectly sets the iframe size in dialog windows.

## CKEditor 4.1.2

New Features:

* Added new translation: Sinhala.

Fixed Issues:

* (http://dev.ckeditor.com/ticket/10339): Fixed: Error thrown when inserted data was totally stripped out after filtering and processing.
* (http://dev.ckeditor.com/ticket/10298): Fixed: Data processor breaks attributes containing protected parts.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editable-method-insertText) loses characters when `RegExp` replace controls are being inserted.
*  Access denied error when `document.domain` has been altered.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-setReadOnly).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-customConfig) files.
* (http://docs.ckeditor.com/#!/api/CKEDITOR-property-ENTER_BR).
* (http://dev.ckeditor.com/ticket/10360): Fixed: ARIA `role="application"` should not be used for dialog windows.
* (http://dev.ckeditor.com/ticket/10361): Fixed: ARIA `role="application"` should not be used for floating panels.
* (http://dev.ckeditor.com/ticket/10510): Introduced unique voice labels to differentiate between different editor instances.
*  Scrolling not possible on iPad.
* (http://dev.ckeditor.com/ticket/10389): Fixed: Invalid HTML in the "Text and Table" template.
* (http://ckeditor.com/addon/wsc) plugin user interface was changed to match CKEditor 4 style.

## CKEditor 4.1.1

New Features:

* Added new translation: Albanian.

Fixed Issues:

* (http://dev.ckeditor.com/ticket/10172): Pressing *Delete* or *Backspace* in an empty table cell moves the cursor to the next/previous cell.
* (http://dev.ckeditor.com/ticket/10219): Error thrown when destroying an editor instance in parallel with a `mouseup` event.
* (http://ckeditor.com/addon/filebrowser) plugin.
* (http://dev.ckeditor.com/ticket/10249): Wrong undo/redo states at start.
* (http://ckeditor.com/addon/showblocks) does not recover after switching to Source view.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.htmlDataProcessor).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-enterMode).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-tabSpaces). Unified `data-cke-*` attributes filtering.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.undo.UndoManager) should not record snapshots after a filling character was added/removed.
*  Space after a filling character should be secured.
*  The filling character is not removed on `keydown` in specific cases.
* (http://dev.ckeditor.com/ticket/10285): Fixed: Styled text pasted from MS Word causes an infinite loop.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.plugins.undo.UndoManager-method-update) does not refresh the command state.
* (http://ckeditor.com/addon/removeformat).

## CKEditor 4.1

Fixed Issues:

* (http://docs.ckeditor.com/#!/guide/dev_advanced_content_filter) in several cases.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.filter-property-allowedContent) property always contains rules in the same format.
* (http://dev.ckeditor.com/ticket/10224): Advanced Content Filter does not remove non-empty `<a>` elements anymore.
* Minor issues in plugin integration with Advanced Content Filter:
  * (http://dev.ckeditor.com/ticket/10166): Added transformation from the `align` attribute to `float` style to preserve backward compatibility after the introduction of Advanced Content Filter.
  * (http://ckeditor.com/addon/image) plugin no longer registers rules for links to Advanced Content Filter.
  * (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-justifyClasses) is defined.

## CKEditor 4.1 RC

New Features:

* (http://dev.ckeditor.com/ticket/9829): Advanced Content Filter - data and features activation based on editor configuration.

  Brand new data filtering system that works in 2 modes:

  * Based on loaded features (toolbar items, plugins) - the data will be filtered according to what the editor in its
  current configuration can handle.
  * Based on (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-allowedContent) rules - the data
  will be filtered and the editor features (toolbar items, commands, keystrokes) will be enabled if they are allowed.

  See the `datafiltering.html` sample, (http://docs.ckeditor.com/#!/api/CKEDITOR.filter).
* (http://ckeditor.com/addon/sharedspace) - the ability to display toolbar and bottom editor space in selected locations and to share them by different editor instances.
* (http://docs.ckeditor.com/#!/api/CKEDITOR-event-contentPreview) event for preview data manipulation.
* (http://ckeditor.com/addon/sourcedialog) plugin that brings raw HTML editing for inline editor instances.
* Included in (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-toDataFormat), allowing for better integration with data processing.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.htmlParser.filter)s before writing structure to an HTML string.
* Included in (http://dev.ckeditor.com/ticket/10103):
  * Introduced the (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-status) property to make it easier to check the current status of the editor.
  * Default (http://docs.ckeditor.com/#!/api/CKEDITOR-event-instanceReady) or immediately after being added if the editor is already initialized.
* (http://dev.ckeditor.com/ticket/9796): Introduced `<s>` as a default tag for strikethrough, which replaces obsolete `<strike>` in HTML5.

## CKEditor 4.0.3

Fixed Issues:

* (http://ckeditor.com/addon/autogrow) is enabled.
*  Undo command throws errors after multiple switches between Source and WYSIWYG view.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-destroy).

## CKEditor 4.0.2

Fixed Issues:

* (http://docs.ckeditor.com/#!/api/CKEDITOR-method-getUrl) with `CKEDITOR_GETURL`.
* (http://ckeditor.com/addon/kama) skins).
* (http://docs.ckeditor.com/#!/api/CKEDITOR.stylesSet-method-add) are displayed in the wrong order.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-property-readOnly) is set.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-getData) if set via the Document Properties dialog window.
* (http://dev.ckeditor.com/ticket/9773): Fixed rendering problems with selection fields in the Kama skin.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-event-selectionChange) event is not fired when mouse selection ended outside editable.
*  Bad positioning of floating space with page horizontal scroll.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-checkDirty) returns `true` when called onload. Removed the obsolete `editor.mayBeDirty` flag.
*  Fixed broken toolbar when editing mixed direction content in Quirks mode.
* (http://ckeditor.com/addon/link) dialog window when the Anchor option is used and no anchors are available.
* (http://ckeditor.com/addon/divarea)-based editors.
*  Navigating back to a page with the editor was making the entire page editable.
* (http://ckeditor.com/addon/magicline) keystrokes.
*  Selection is moved before editable position when the editor is focused for the first time.
*  Editor overflows parent container in some edge cases.
* (http://ckeditor.com/addon/sourcearea) view when an RTL language is set.
*  Fixed: Several dialog windows have broken layout since the latest WebKit release.
* (http://dev.ckeditor.com/ticket/10152): Fixed: Invalid ARIA property used on menu items.

## CKEditor 4.0.1.1

Fixed Issues:

* Security update: Added protection against XSS attack and possible path disclosure in the PHP sample.

## CKEditor 4.0.1

Fixed Issues:

* (http://ckeditor.com/addon/moono).
* Accessibility issues (mainly in inline editor): (http://dev.ckeditor.com/ticket/9844).
* (http://ckeditor.com/addon/magicline) plugin:
    * (http://dev.ckeditor.com/ticket/9481): Added accessibility support for Magic Line.
    * (http://dev.ckeditor.com/ticket/9509): Added Magic Line support for forms.
    * (http://dev.ckeditor.com/ticket/9573): Magic Line does not disappear on `mouseout` in a specific case.
*  Cutting & pasting simple unformatted text generates an inline wrapper in WebKit browsers.
*  Properly paste bullet list style from MS Word.
* (http://dev.ckeditor.com/ticket/9758): Improved selection locking when selecting by dragging.
* Context menu:
    * (http://dev.ckeditor.com/ticket/9712): Opening the context menu destroys editor focus.
    * (http://dev.ckeditor.com/ticket/9366): Context menu should be displayed over the floating toolbar.
    * (http://dev.ckeditor.com/ticket/9706): Context menu generates a JavaScript error in inline mode when the editor is attached to a header element.
* (http://dev.ckeditor.com/ticket/9800): Hide float panel when resizing the window.
* (http://dev.ckeditor.com/ticket/9721): Padding in content of div-based editor puts the editing area under the bottom UI space.
* (http://dev.ckeditor.com/ticket/9528): Host page `box-sizing` style should not influence the editor UI elements.
* (http://ckeditor.com/addon/forms) plugin adds context menu listeners only on supported input types. Added support for `tel`, `email`, `search` and `url` input types.
* (http://dev.ckeditor.com/ticket/9769): Improved floating toolbar positioning in a narrow window.
* (http://dev.ckeditor.com/ticket/9875): Table dialog window does not populate width correctly.
* (http://dev.ckeditor.com/ticket/8675): Deleting cells in a nested table removes the outer table cell.
* (http://dev.ckeditor.com/ticket/9815): Cannot edit dialog window fields in an editor initialized in the jQuery UI modal dialog.
* (http://dev.ckeditor.com/ticket/8888): CKEditor dialog windows do not show completely in a small window.
*  Blocks shown for a `<div>` element stay permanently even after the user exits editing the `<div>`.
*  Toolbar is lost when closing the Format drop-down list by clicking its button.
* (http://dev.ckeditor.com/ticket/9553): Table width incorrectly set when the `border-width` style is specified.
* (http://dev.ckeditor.com/ticket/9594): Cannot tab past CKEditor when it is in read-only mode.
*  Justify not working on selected images.
* (http://dev.ckeditor.com/ticket/9686): Added missing contents styles for `<pre>` elements.
* (http://ckeditor.com/addon/pastefromword) should not depend on configuration from other styles.
* (http://ckeditor.com/addon/tabletools).
* (http://ckeditor.com/addon/a11yhelp) dialog window.
*  Fixed scrolling issues when pasting.
*  `onChange` is not fired for checkboxes in dialogs.
*  When opening a toolbar menu for the first time and pressing the *Down Arrow* key, focus goes to the next toolbar button instead of the menu options.
* (http://ckeditor.com/addon/elementspath) should not be initialized in the inline editor.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.editor-method-addRemoveFormatFilter) is exposed before it really works.
* (http://docs.ckeditor.com/#!/api/CKEDITOR.config-cfg-pasteFromWordCleanupFile) configuration option is now taken from the instance configuration.
* (http://dev.ckeditor.com/ticket/9693): Removed "Live Preview" checkbox from UI color picker.


## CKEditor 4.0

The first stable release of the new CKEditor 4 code line.

The CKEditor JavaScript API has been kept compatible with CKEditor 4, whenever
possible. The list of relevant changes can be found in the [API Changes page of
the CKEditor 4 documentation].

: http://docs.ckeditor.com/#!/guide/dev_api_changes "API Changes"
