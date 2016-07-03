function solve(args) {
    "use strict";

    function appendControllers(elements, app, apps, elementType) {
        for (let element in elements) {
            if (elements.hasOwnProperty(element)) {

                if (elements[element].indexOf(app) !== -1) {
                    apps[app][elementType].push(element);
                }
            }
        }
    }

    function initializeInput(args, apps, controllers, models, views) {
        let appRegex = /\$app='([^']+)'/m;
        let controllerRegex = /\$controller='([^']+)'&app='([^']+)'/m;
        let modelsRegex = /\$model='([^']+)'&app='([^']+)'/m;
        let viewRegex = /\$view='([^']+)'&app='([^']+)'/m;

        for (let line of args) {
            let appMatch = appRegex.exec(line);

            if (appMatch) {
                let appName = appMatch[1];
                apps[appName] = {};
                continue;
            }

            let controllerMatch = controllerRegex.exec(line);
            if (controllerMatch) {
                let controllerName = controllerMatch[1];
                let appName = controllerMatch[2];

                if (!controllers[controllerName]) {
                    controllers[controllerName] = [];
                }

                controllers[controllerName].push(appName);
                continue;
            }

            let modelMatch = modelsRegex.exec(line);
            if (modelMatch) {
                let modelName = modelMatch[1];
                let appName = modelMatch[2];

                if (!models[modelName]) {
                    models[modelName] = [];
                }

                models[modelName].push(appName);
                continue;
            }

            let viewMatch = viewRegex.exec(line);
            if (viewMatch) {
                let viewName = viewMatch[1];
                let appName = viewMatch[2];

                if (!views[viewName]) {
                    views[viewName] = [];
                }

                views[viewName].push(appName);
            }
        }
    }

    function initializeApps(apps, controllers, models, views) {
        for (let app in apps) {
            if (apps.hasOwnProperty(app)) {
                apps[app]['controllers'] = [];
                apps[app]['models'] = [];
                apps[app]['views'] = [];

                appendControllers(controllers, app, apps, 'controllers');
                apps[app]['controllers'].sort();

                appendControllers(models, app, apps, 'models');
                apps[app]['models'].sort();

                appendControllers(views, app, apps, 'views');
                apps[app]['views'].sort();
            }
        }
    }

    function sortApps(apps) {
        let sortedKeys = [];

        for (let appIndex in apps) {
            if (apps.hasOwnProperty(appIndex)) {
                let obj = JSON.parse(JSON.stringify(apps[appIndex]));
                obj.app = appIndex;
                sortedKeys.push(obj);
            }
        }

        sortedKeys = sortedKeys.sort(function (firstApp, secondApp) {
            if (firstApp.controllers.length === secondApp.controllers.length) {
                return firstApp.models.length - secondApp.models.length;
            } else {
                return secondApp.controllers.length - firstApp.controllers.length;
            }
        });

        let sortedApps = {};
        for (let key of sortedKeys) {
            sortedApps[key.app] = apps[key.app];
        }

        return sortedApps;
    }

    let apps = {};
    let controllers = {};
    let models = {};
    let views = {};

    initializeInput(args, apps, controllers, models, views);

    initializeApps(apps, controllers, models, views);

    apps = sortApps(apps);
    console.log(JSON.stringify(apps));
}

// solve([
//     '$app=\'MyApp\'',
//     '$controller=\'My Controller\'&app=\'MyApp\'',
//     '$model=\'My Model\'&app=\'MyApp\'',
//     '$view=\'My View\'&app=\'MyApp\'',
//     '$view=\'My View\'&app=\'MyApp2\'']);

solve([
    '$controller=\'PHPController\'&app=\'Language Parser\'',
    '$controller=\'JavaController\'&app=\'Language Parser\'',
    '$controller=\'C#Controller\'&app=\'Language Parser\'',
    '$controller=\'C++Controller\'&app=\'Language Parser\'',
    '$app=\'Garbage Collector\'',
    '$controller=\'GarbageController\'&app=\'Garbage Collector\'',
    '$controller=\'SpamController\'&app=\'Garbage Collector\'',
    '$app=\'Language Parser\''
]);