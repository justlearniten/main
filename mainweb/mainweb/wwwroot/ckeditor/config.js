/**
 * @license Copyright (c) 2003-2017, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function( config ) {
	// Define changes to default configuration here.
	// For complete reference see:
	// http://docs.ckeditor.com/#!/api/CKEDITOR.config

	// The toolbar groups arrangement, optimized for two toolbar rows.
    config.toolbarGroups = [
        { name: 'clipboard', groups:  },
        { name: 'editing', groups:  },
        { name: 'links', groups:  },
        { name: 'insert', groups:  },
        { name: 'forms', groups:  },
        { name: 'tools', groups:  },
        { name: 'document', groups:  },
        { name: 'others', groups:  },
        '/',
        { name: 'basicstyles', groups:  },
        { name: 'paragraph', groups:  },
        { name: 'styles', groups:  },
        { name: 'colors', groups:  },
        { name: 'about', groups:  }
    ];

    config.removeButtons = 'Underline,Subscript,Superscript,PasteText,PasteFromWord,Anchor,Format';

	// Set the most common block elements.
	config.format_tags = 'p;h1;h2;h3;pre';

	// Simplify the dialog windows.
    config.removeDialogTabs = 'image:advanced;link:advanced';

    //plugins
    config.extraPlugins = 'justify,button,panel,panelbutton,floatpanel,colorbutton,train,exercise';
    config.contentsCss = '/css/lessons.css';

    config.allowedContent = true;
};
