import * as React from 'react';
import * as ReactRouter from 'react-router';
import * as LibreAtom from '@libre/atom';

declare module "consumer-portal" {
  /**
   * Defines the API accessible from pilets.
   */
  export interface PiletApi extends EventEmitter, PiletCustomApi, PiletCoreApi {
    /**
     * Gets the metadata of the current pilet.
     */
    meta: PiletMetadata;
  }

  /**
   * The emitter for Piral app shell events.
   */
  export interface EventEmitter {
    /**
     * Attaches a new event listener.
     * @param type The type of the event to listen for.
     * @param callback The callback to trigger.
     */
    on<K extends keyof PiralEventMap>(type: K, callback: Listener<PiralEventMap[K]>): EventEmitter;
    /**
     * Detaches an existing event listener.
     * @param type The type of the event to listen for.
     * @param callback The callback to trigger.
     */
    off<K extends keyof PiralEventMap>(type: K, callback: Listener<PiralEventMap[K]>): EventEmitter;
    /**
     * Emits a new event with the given type.
     * @param type The type of the event to emit.
     * @param arg The payload of the event.
     */
    emit<K extends keyof PiralEventMap>(type: K, arg: PiralEventMap[K]): EventEmitter;
  }

  /**
   * Custom Pilet API parts defined outside of piral-core.
   */
  export interface PiletCustomApi extends PiletLocaleApi, PiletDashboardApi, PiletMenuApi, PiletNotificationsApi, PiletModalsApi, PiletFeedsApi {}

  /**
   * Defines the Pilet API from piral-core.
   * This interface will be consumed by pilet developers so that their pilet can interact with the piral instance.
   */
  export interface PiletCoreApi {
    /**
     * Gets a shared data value.
     * @param name The name of the data to retrieve.
     */
    getData<TKey extends string>(name: TKey): SharedData[TKey];
    /**
     * Sets the data using a given name. The name needs to be used exclusively by the current pilet.
     * Using the name occupied by another pilet will result in no change.
     * @param name The name of the data to store.
     * @param value The value of the data to store.
     * @param options The optional configuration for storing this piece of data.
     * @returns True if the data could be set, otherwise false.
     */
    setData<TKey extends string>(name: TKey, value: SharedData[TKey], options?: DataStoreOptions): boolean;
    /**
     * Registers a route for predefined page component.
     * The route needs to be unique and can contain params.
     * Params are following the path-to-regexp notation, e.g., :id for an id parameter.
     * @param route The route to register.
     * @param Component The component to render the page.
     * @param meta The optional metadata to use.
     */
    registerPage(route: string, Component: AnyComponent<PageComponentProps>, meta?: PiralPageMeta): RegistrationDisposer;
    /**
     * Unregisters the page identified by the given route.
     * @param route The route that was previously registered.
     */
    unregisterPage(route: string): void;
    /**
     * Registers an extension component with a predefined extension component.
     * The name must refer to the extension slot.
     * @param name The global name of the extension slot.
     * @param Component The component to be rendered.
     * @param defaults Optionally, sets the default values for the expected data.
     */
    registerExtension<TName>(name: TName extends string ? TName : string, Component: AnyComponent<ExtensionComponentProps<TName>>, defaults?: TName): RegistrationDisposer;
    /**
     * Unregisters a global extension component.
     * Only previously registered extension components can be unregistered.
     * @param name The name of the extension slot to unregister from.
     * @param Component The registered extension component to unregister.
     */
    unregisterExtension<TName>(name: TName extends string ? TName : string, Component: AnyComponent<ExtensionComponentProps<TName>>): void;
    /**
     * React component for displaying extensions for a given name.
     * @param props The extension's rendering props.
     * @return The created React element.
     */
    Extension<TName>(props: ExtensionSlotProps<TName>): React.ReactElement | null;
    /**
     * Renders an extension in a plain DOM component.
     * @param element The DOM element or shadow root as a container for rendering the extension.
     * @param props The extension's rendering props.
     */
    renderHtmlExtension<TName>(element: HTMLElement | ShadowRoot, props: ExtensionSlotProps<TName>): void;
  }

  /**
   * Describes the metadata transported by a pilet.
   */
  export type PiletMetadata = SinglePiletMetadata | MultiPiletMetadata;

  /**
   * Listener for Piral app shell events.
   */
  export interface Listener<T> {
    (arg: T): void;
  }

  /**
   * The map of known Piral app shell events.
   */
  export interface PiralEventMap extends PiralCustomEventMap {
    [custom: string]: any;
    "store-data": PiralStoreDataEvent;
    "unload-pilet": PiralUnloadPiletEvent;
  }

  export interface PiletLocaleApi {
    /**
     * Translates the given tag (using the optional variables) into a string using the current language.
     * The used template can contain placeholders in form of `{{variableName}}`.
     * @param tag The tag to translate.
     * @param variables The optional variables to fill into the temnplate.
     */
    translate<T = Record<string, string>>(tag: string, variables?: T): string;
    /**
     * Provides translations to the application.
     * The translations will be exclusively used for retrieving translations for the pilet.
     * @param messages The messages to use as translation basis.
     */
    setTranslations(messages: LocalizationMessages): void;
    /**
     * Gets the currently provided translations by the pilet.
     */
    getTranslations(): LocalizationMessages;
  }

  export interface PiletDashboardApi {
    /**
     * Registers a tile with a predefined tile components.
     * The name has to be unique within the current pilet.
     * @param name The name of the tile.
     * @param Component The component to be rendered within the Dashboard.
     * @param preferences The optional preferences to be supplied to the Dashboard for the tile.
     */
    registerTile(name: string, Component: AnyComponent<TileComponentProps>, preferences?: TilePreferences): RegistrationDisposer;
    /**
     * Registers a tile for predefined tile components.
     * @param Component The component to be rendered within the Dashboard.
     * @param preferences The optional preferences to be supplied to the Dashboard for the tile.
     */
    registerTile(Component: AnyComponent<TileComponentProps>, preferences?: TilePreferences): RegistrationDisposer;
    /**
     * Unregisters a tile known by the given name.
     * Only previously registered tiles can be unregistered.
     * @param name The name of the tile to unregister.
     */
    unregisterTile(name: string): void;
  }

  export interface PiletMenuApi {
    /**
     * Registers a menu item for a predefined menu component.
     * The name has to be unique within the current pilet.
     * @param name The name of the menu item.
     * @param Component The component to be rendered within the menu.
     * @param settings The optional configuration for the menu item.
     */
    registerMenu(name: string, Component: AnyComponent<MenuComponentProps>, settings?: MenuSettings): RegistrationDisposer;
    /**
     * Registers a menu item for a predefined menu component.
     * @param Component The component to be rendered within the menu.
     * @param settings The optional configuration for the menu item.
     */
    registerMenu(Component: AnyComponent<MenuComponentProps>, settings?: MenuSettings): RegistrationDisposer;
    /**
     * Unregisters a menu item known by the given name.
     * Only previously registered menu items can be unregistered.
     * @param name The name of the menu item to unregister.
     */
    unregisterMenu(name: string): void;
  }

  export interface PiletNotificationsApi {
    /**
     * Shows a notification in the determined spot using the provided content.
     * @param content The content to display. Normally, a string would be sufficient.
     * @param options The options to consider for showing the notification.
     * @returns A callback to trigger closing the notification.
     */
    showNotification(content: string | React.ReactElement<any, any> | AnyComponent<NotificationComponentProps>, options?: NotificationOptions): Disposable;
  }

  export interface PiletModalsApi {
    /**
     * Shows a modal dialog with the given name.
     * The modal can be optionally programmatically closed using the returned callback.
     * @param name The name of the registered modal.
     * @param options Optional arguments for creating the modal.
     * @returns A callback to trigger closing the modal.
     */
    showModal<T>(name: T extends string ? T : string, options?: ModalOptions<T>): Disposable;
    /**
     * Registers a modal dialog using a React component.
     * The name needs to be unique to be used without the pilet's name.
     * @param name The name of the modal to register.
     * @param Component The component to render the page.
     * @param defaults Optionally, sets the default values for the inserted options.
     */
    registerModal<T>(name: T extends string ? T : string, Component: AnyComponent<ModalComponentProps<T>>, defaults?: ModalOptions<T>): RegistrationDisposer;
    /**
     * Unregisters a modal by its name.
     * @param name The name that was previously registered.
     */
    unregisterModal<T>(name: T extends string ? T : string): void;
  }

  export interface PiletFeedsApi {
    /**
     * Creates a connector for wrapping components with data relations.
     * @param resolver The resolver for the initial data set.
     */
    createConnector<T>(resolver: FeedResolver<T>): FeedConnector<T>;
    /**
     * Creates a connector for wrapping components with data relations.
     * @param options The options for creating the connector.
     */
    createConnector<TData, TItem, TReducers extends FeedConnectorReducers<TData>>(options: FeedConnectorOptions<TData, TItem, TReducers>): FeedConnector<TData, TReducers>;
  }

  /**
   * Defines the shape of the data store for storing shared data.
   */
  export interface SharedData<TValue = any> {
    [key: string]: TValue;
  }

  /**
   * Defines the options to be used for storing data.
   */
  export type DataStoreOptions = DataStoreTarget | CustomDataStoreOptions;

  /**
   * Possible shapes for a component.
   */
  export type AnyComponent<T> = React.ComponentType<T> | FirstParametersOf<ComponentConverters<T>>;

  /**
   * The props used by a page component.
   */
  export interface PageComponentProps<T = any, S = any> extends RouteBaseProps<T, S> {}

  /**
   * The meta data registered for a page.
   */
  export interface PiralPageMeta extends PiralCustomPageMeta {}

  /**
   * The shape of an implicit unregister function.
   */
  export interface RegistrationDisposer {
    (): void;
  }

  /**
   * The props of an extension component.
   */
  export interface ExtensionComponentProps<T> extends BaseComponentProps {
    /**
     * The provided parameters for showing the extension.
     */
    params: T extends keyof PiralExtensionSlotMap ? PiralExtensionSlotMap[T] : T extends string ? any : T;
  }

  /**
   * The props for defining an extension slot.
   */
  export type ExtensionSlotProps<K = string> = BaseExtensionSlotProps<K extends string ? K : string, K extends keyof PiralExtensionSlotMap ? PiralExtensionSlotMap[K] : K extends string ? any : K>;

  /**
   * The metadata response for a single pilet.
   */
  export type SinglePiletMetadata = PiletMetadataV0 | PiletMetadataV1;

  /**
   * The metadata response for a multi pilet.
   */
  export type MultiPiletMetadata = PiletMetadataBundle;

  /**
   * Custom events defined outside of piral-core.
   */
  export interface PiralCustomEventMap {}

  /**
   * Gets fired when a data item gets stored in piral.
   */
  export interface PiralStoreDataEvent<TValue = any> {
    /**
     * The name of the item that was stored.
     */
    name: string;
    /**
     * The storage target of the item.
     */
    target: string;
    /**
     * The value that was stored.
     */
    value: TValue;
    /**
     * The owner of the item.
     */
    owner: string;
    /**
     * The expiration of the item.
     */
    expires: number;
  }

  /**
   * Gets fired when a pilet gets unloaded.
   */
  export interface PiralUnloadPiletEvent {
    /**
     * The name of the pilet to be unloaded.
     */
    name: string;
  }

  export interface LocalizationMessages {
    [lang: string]: Translations;
  }

  export type TileComponentProps = BaseComponentProps & BareTileComponentProps;

  export interface TilePreferences extends PiralCustomTilePreferences {
    /**
     * Sets the desired initial number of columns.
     * This may be overridden either by the user (if resizable true), or by the dashboard.
     */
    initialColumns?: number;
    /**
     * Sets the desired initial number of rows.
     * This may be overridden either by the user (if resizable true), or by the dashboard.
     */
    initialRows?: number;
    /**
     * Determines if the tile can be resized by the user.
     * By default the size of the tile is fixed.
     */
    resizable?: boolean;
    /**
     * Declares a set of custom properties to be used with user-specified values.
     */
    customProperties?: Array<string>;
  }

  export interface MenuComponentProps extends BaseComponentProps {}

  export interface MenuSettings extends PiralCustomMenuSettings {
    /**
     * Sets the type of the menu to attach to.
     * @default "general"
     */
    type?: MenuType;
  }

  export type NotificationComponentProps = BaseComponentProps & BareNotificationProps;

  export interface NotificationOptions extends PiralCustomNotificationOptions {
    /**
     * The title of the notification, if any.
     */
    title?: string;
    /**
     * Determines when the notification should automatically close in milliseconds.
     * A value of 0 or undefined forces the user to close the notification.
     */
    autoClose?: number;
    /**
     * The type of the notification used when displaying the message.
     * By default info is used.
     */
    type?: "info" | "success" | "warning" | "error";
  }

  /**
   * Can be implemented by functions to be used for disposal purposes.
   */
  export interface Disposable {
    (): void;
  }

  export type ModalOptions<T> = T extends keyof PiralModalsMap ? PiralModalsMap[T] & BaseModalOptions : T extends string ? BaseModalOptions : T;

  export type ModalComponentProps<T> = BaseComponentProps & BareModalComponentProps<ModalOptions<T>>;

  export interface FeedResolver<TData> {
    (): Promise<TData>;
  }

  export type FeedConnector<TData, TReducers = {}> = GetActions<TReducers> & {
    <TProps>(component: React.ComponentType<TProps & FeedConnectorProps<TData>>): React.FC<TProps>;
    /**
     * Invalidates the underlying feed connector.
     * Forces a reload on next use.
     */
    invalidate(): void;
  };

  export interface FeedConnectorOptions<TData, TItem, TReducers extends FeedConnectorReducers<TData> = {}> {
    /**
     * Function to derive the initial set of data.
     * @returns The promise for retrieving the initial data set.
     */
    initialize: FeedResolver<TData>;
    /**
     * Function to be called for connecting to a live data feed.
     * @param callback The function to call when an item updated.
     * @returns A callback for disconnecting from the feed.
     */
    connect?: FeedSubscriber<TItem>;
    /**
     * Function to be called when some data updated.
     * @param data The current set of data.
     * @param item The updated item to include.
     * @returns The promise for retrieving the updated data set or the updated data set.
     */
    update?: FeedReducer<TData, TItem>;
    /**
     * Defines the optional reducers for modifying the data state.
     */
    reducers?: TReducers;
    /**
     * Optional flag to avoid lazy loading and initialize the data directly.
     */
    immediately?: boolean;
  }

  export interface FeedConnectorReducers<TData> {
    [name: string]: (data: TData, ...args: any) => Promise<TData> | TData;
  }

  /**
   * Defines the potential targets when storing data.
   */
  export type DataStoreTarget = "memory" | "local" | "remote";

  /**
   * Defines the custom options for storing data.
   */
  export interface CustomDataStoreOptions {
    /**
     * The target data store. By default the data is only stored in memory.
     */
    target?: DataStoreTarget;
    /**
     * Optionally determines when the data expires.
     */
    expires?: "never" | Date | number;
  }

  export type FirstParametersOf<T> = {
    [K in keyof T]: T[K] extends (arg: any) => any ? FirstParameter<T[K]> : never;
  }[keyof T];

  /**
   * Mapping of available component converters.
   */
  export interface ComponentConverters<TProps> extends PiralCustomComponentConverters<TProps> {
    /**
     * Converts the HTML component to a framework-independent component.
     * @param component The vanilla JavaScript component to be converted.
     */
    html(component: HtmlComponent<TProps>): ForeignComponent<TProps>;
  }

  /**
   * The props that every registered page component obtains.
   */
  export interface RouteBaseProps<UrlParams = any, UrlState = any> extends ReactRouter.RouteComponentProps<UrlParams, {}, UrlState>, BaseComponentProps {}

  /**
   * Custom meta data to include for pages.
   */
  export interface PiralCustomPageMeta {}

  /**
   * The props that every registered component obtains.
   */
  export interface BaseComponentProps {
    /**
     * The currently used pilet API.
     */
    piral: PiletApi;
  }

  /**
   * The mapping of the existing (known) extension slots.
   */
  export interface PiralExtensionSlotMap extends PiralCustomExtensionSlotMap {}

  /**
   * The basic props for defining an extension slot.
   */
  export interface BaseExtensionSlotProps<TName, TParams> {
    /**
     * Defines what should be rendered when no components are available
     * for the specified extension.
     */
    empty?(): React.ReactNode;
    /**
     * Defines how the provided nodes should be rendered.
     * @param nodes The rendered extension nodes.
     */
    render?(nodes: Array<React.ReactNode>): React.ReactElement<any, any> | null;
    /**
     * The custom parameters for the given extension.
     */
    params?: TParams;
    /**
     * The name of the extension to render.
     */
    name: TName;
  }

  /**
   * Metadata for pilets using the v0 schema.
   */
  export interface PiletMetadataV0 {
    /**
     * The name of the pilet, i.e., the package id.
     */
    name: string;
    /**
     * The version of the pilet. Should be semantically versioned.
     */
    version: string;
    /**
     * The content of the pilet. If the content is not available
     * the link will be used (unless caching has been activated).
     */
    content?: string;
    /**
     * The link for retrieving the content of the pilet.
     */
    link?: string;
    /**
     * The computed hash value of the pilet's content. Should be
     * accurate to allow caching.
     */
    hash: string;
    /**
     * If available indicates that the pilet should not be cached.
     * In case of a string this is interpreted as the expiration time
     * of the cache. In case of an accurate hash this should not be
     * required or set.
     */
    noCache?: boolean | string;
    /**
     * Optionally provides some custom metadata for the pilet.
     */
    custom?: any;
  }

  /**
   * Metadata for pilets using the v1 schema.
   */
  export interface PiletMetadataV1 {
    /**
     * The name of the pilet, i.e., the package id.
     */
    name: string;
    /**
     * The version of the pilet. Should be semantically versioned.
     */
    version: string;
    /**
     * The link for retrieving the content of the pilet.
     */
    link: string;
    /**
     * The reference name for the global require.
     */
    requireRef: string;
    /**
     * The computed integrity of the pilet. Will be used to set the
     * integrity value of the script.
     */
    integrity?: string;
    /**
     * Optionally provides some custom metadata for the pilet.
     */
    custom?: any;
  }

  /**
   * Metadata for pilets using the bundle schema.
   */
  export interface PiletMetadataBundle {
    /**
     * The name of the bundle pilet, i.e., the package id.
     */
    name?: string;
    /**
     * The link for retrieving the bundle content of the pilet.
     */
    link: string;
    /**
     * The reference name for the global bundle-shared require.
     */
    bundle: string;
    /**
     * The computed integrity of the pilet. Will be used to set the
     * integrity value of the script.
     */
    integrity?: string;
    /**
     * Optionally provides some custom metadata for the pilet.
     */
    custom?: any;
  }

  export interface Translations {
    [tag: string]: string;
  }

  export interface BareTileComponentProps {
    /**
     * The currently used number of columns.
     */
    columns: number;
    /**
     * The currently used number of rows.
     */
    rows: number;
  }

  export interface PiralCustomTilePreferences {}

  export interface PiralCustomMenuSettings {}

  export type MenuType = StandardMenuType | keyof PiralCustomMenuTypes;

  export interface BareNotificationProps {
    /**
     * Callback for closing the notification programmatically.
     */
    onClose(): void;
    /**
     * Provides the passed in options for this particular notification.
     */
    options: NotificationOptions;
  }

  export interface PiralCustomNotificationOptions {}

  export interface BaseModalOptions {}

  export interface PiralModalsMap extends PiralCustomModalsMap {}

  export interface BareModalComponentProps<TOpts> {
    /**
     * Callback for closing the modal programmatically.
     */
    onClose(): void;
    /**
     * Provides the passed in options for this particular modal.
     */
    options?: TOpts;
  }

  export type GetActions<TReducers> = {
    [P in keyof TReducers]: (...args: RemainingArgs<TReducers[P]>) => void;
  };

  export interface FeedConnectorProps<TData> {
    /**
     * The current data from the feed.
     */
    data: TData;
  }

  export interface FeedSubscriber<TItem> {
    (callback: (value: TItem) => void): Disposable;
  }

  export interface FeedReducer<TData, TAction> {
    (data: TData, item: TAction): Promise<TData> | TData;
  }

  export type FirstParameter<T extends (arg: any) => any> = T extends (arg: infer P) => any ? P : never;

  /**
   * Custom component converters defined outside of piral-core.
   */
  export interface PiralCustomComponentConverters<TProps> {}

  /**
   * Definition of a vanilla JavaScript component.
   */
  export interface HtmlComponent<TProps> {
    /**
     * Renders a component into the provided element using the given props and context.
     */
    component: ForeignComponent<TProps>;
    /**
     * The type of the HTML component.
     */
    type: "html";
  }

  /**
   * Generic definition of a framework-independent component.
   */
  export interface ForeignComponent<TProps> {
    /**
     * Called when the component is mounted.
     * @param element The container hosting the element.
     * @param props The props to transport.
     * @param ctx The associated context.
     */
    mount(element: HTMLElement, props: TProps, ctx: ComponentContext): void;
    /**
     * Called when the component should be updated.
     * @param element The container hosting the element.
     * @param props The props to transport.
     * @param ctx The associated context.
     */
    update?(element: HTMLElement, props: TProps, ctx: ComponentContext): void;
    /**
     * Called when a component is unmounted.
     * @param element The container that was hosting the element.
     */
    unmount?(element: HTMLElement): void;
  }

  /**
   * Custom extension slots outside of piral-core.
   */
  export interface PiralCustomExtensionSlotMap {}

  export type StandardMenuType = "general" | "admin" | "user" | "header" | "footer";

  export interface PiralCustomMenuTypes {}

  export interface PiralCustomModalsMap {}

  export type RemainingArgs<T> = T extends (_: any, ...args: infer U) => any ? U : never;

  /**
   * The context to be transported into the generic components.
   */
  export interface ComponentContext {
    router: ReactRouter.RouteComponentProps;
    state: LibreAtom.Atom<GlobalState>;
  }

  /**
   * The Piral global app state container.
   */
  export interface GlobalState extends PiralCustomState {
    /**
     * The relevant state for the app itself.
     */
    app: AppState;
    /**
     * The relevant state for rendering errors of the app.
     */
    errorComponents: ErrorComponentsState;
    /**
     * The relevant state for rendering parts of the app.
     */
    components: ComponentsState;
    /**
     * The relevant state for the registered components.
     */
    registry: RegistryState;
    /**
     * Gets the loaded modules.
     */
    modules: Array<PiletMetadata>;
    /**
     * The foreign component portals to render.
     */
    portals: Record<string, Array<React.ReactPortal>>;
    /**
     * The application's shared data.
     */
    data: Dict<SharedDataItem>;
    /**
     * The used (exact) application routes.
     */
    routes: Dict<React.ComponentType<ReactRouter.RouteComponentProps<any>>>;
    /**
     * The current provider.
     */
    provider?: React.ComponentType;
  }

  /**
   * Custom state extensions defined outside of piral-core.
   */
  export interface PiralCustomState {
    /**
     * Information for the language display.
     */
    language: {
      /**
       * Gets if languages are currently loading.
       */
      loading: boolean;
      /**
       * The selected, i.e., active, language.
       */
      selected: string;
      /**
       * The available languages.
       */
      available: Array<string>;
    };
    /**
     * The currently open notifications.
     */
    notifications: Array<OpenNotification>;
    /**
     * The currently open modal dialogs.
     */
    modals: Array<OpenModalDialog>;
    /**
     * The relevant state for the registered feeds.
     */
    feeds: FeedsState;
  }

  /**
   * The Piral global app sub-state container for app information.
   */
  export interface AppState {
    /**
     * Information for the layout computation.
     */
    layout: LayoutType;
    /**
     * Gets if the application is currently performing a background loading
     * activity, e.g., for loading modules asynchronously or fetching
     * translations.
     */
    loading: boolean;
    /**
     * Gets an unrecoverable application error, if any.
     */
    error: Error | undefined;
  }

  export type ErrorComponentsState = {
    [P in keyof Errors]?: React.ComponentType<Errors[P]>;
  };

  /**
   * The Piral global app sub-state container for shared components.
   */
  export interface ComponentsState extends PiralCustomComponentsState {
    /**
     * The loading indicator renderer.
     */
    LoadingIndicator: React.ComponentType<LoadingIndicatorProps>;
    /**
     * The error renderer.
     */
    ErrorInfo: React.ComponentType<ErrorInfoProps>;
    /**
     * The router context.
     */
    Router: React.ComponentType<RouterProps>;
    /**
     * The layout used for pages.
     */
    Layout: React.ComponentType<LayoutProps>;
    /**
     * A component that can be used for debugging purposes.
     */
    Debug?: React.ComponentType;
  }

  /**
   * The Piral global app sub-state container for component registrations.
   */
  export interface RegistryState extends PiralCustomRegistryState {
    /**
     * The registered page components for the router.
     */
    pages: Dict<PageRegistration>;
    /**
     * The registered extension components for extension slots.
     */
    extensions: Dict<Array<ExtensionRegistration>>;
  }

  export type Dict<T> = Record<string, T>;

  /**
   * Defines the shape of a shared data item.
   */
  export interface SharedDataItem<TValue = any> {
    /**
     * Gets the associated value.
     */
    value: TValue;
    /**
     * Gets the owner of the item.
     */
    owner: string;
    /**
     * Gets the storage location.
     */
    target: DataStoreTarget;
    /**
     * Gets the expiration of the item.
     */
    expires: number;
  }

  export interface OpenNotification {
    id: string;
    component: React.ComponentType<BareNotificationProps>;
    options: NotificationOptions;
    close(): void;
  }

  export interface OpenModalDialog {
    /**
     * Specifies the fully qualified name of the dialog to show.
     */
    name: string;
    /**
     * Specifies the alternative (original) name of the dialog to show.
     */
    alternative?: string;
    /**
     * Defines the transported options.
     */
    options: BaseModalOptions;
    /**
     * Closes the modal dialog.
     */
    close(): void;
  }

  export interface FeedsState {
    [id: string]: FeedDataState;
  }

  /**
   * The different known layout types.
   */
  export type LayoutType = "mobile" | "tablet" | "desktop";

  /**
   * Map of all error types to their respective props.
   */
  export interface Errors extends PiralCustomErrors {
    /**
     * The props type for an extension error.
     */
    extension: ExtensionErrorInfoProps;
    /**
     * The props type for a loading error.
     */
    loading: LoadingErrorInfoProps;
    /**
     * The props type for a page error.
     */
    page: PageErrorInfoProps;
    /**
     * The props type for a not found error.
     */
    not_found: NotFoundErrorInfoProps;
    /**
     * The props type for an unknown error.
     */
    unknown: UnknownErrorInfoProps;
  }

  /**
   * Custom parts of the global custom component state defined outside of piral-core.
   */
  export interface PiralCustomComponentsState {
    /**
     * Represents the component for rendering a language selection.
     */
    LanguagesPicker: React.ComponentType<LanguagesPickerProps>;
    /**
     * The dashboard container component.
     */
    DashboardContainer: React.ComponentType<DashboardContainerProps>;
    /**
     * The dashboard tile component.
     */
    DashboardTile: React.ComponentType<DashboardTileProps>;
    /**
     * The menu container component.
     */
    MenuContainer: React.ComponentType<MenuContainerProps>;
    /**
     * The menu item component.
     */
    MenuItem: React.ComponentType<MenuItemProps>;
    /**
     * The host component for notifications.
     */
    NotificationsHost: React.ComponentType<NotificationsHostProps>;
    /**
     * The notification toast component.
     */
    NotificationsToast: React.ComponentType<NotificationsToastProps>;
    /**
     * The host component for modal dialogs.
     */
    ModalsHost: React.ComponentType<ModalsHostProps>;
    /**
     * The modal dialog component.
     */
    ModalsDialog: React.ComponentType<ModalsDialogProps>;
  }

  /**
   * The props of a Loading indicator component.
   */
  export interface LoadingIndicatorProps {}

  /**
   * The props for the ErrorInfo component.
   */
  export type ErrorInfoProps = UnionOf<Errors>;

  /**
   * The props of a Router component.
   */
  export interface RouterProps {}

  /**
   * The props of a Layout component.
   */
  export interface LayoutProps {
    /**
     * The currently selected layout type.
     */
    currentLayout: LayoutType;
  }

  /**
   * Custom parts of the global registry state defined outside of piral-core.
   */
  export interface PiralCustomRegistryState {
    /**
     * The registered tile components for a dashboard.
     */
    tiles: Dict<TileRegistration>;
    /**
     * The registered menu items for global display.
     */
    menuItems: Dict<MenuItemRegistration>;
    /**
     * The registered modal dialog components.
     */
    modals: Dict<ModalRegistration>;
  }

  /**
   * The interface modeling the registration of a pilet page component.
   */
  export interface PageRegistration extends BaseRegistration {
    component: WrappedComponent<PageComponentProps>;
    meta: PiralPageMeta;
  }

  /**
   * The interface modeling the registration of a pilet extension component.
   */
  export interface ExtensionRegistration extends BaseRegistration {
    component: WrappedComponent<ExtensionComponentProps<string>>;
    reference: any;
    defaults: any;
  }

  export interface FeedDataState {
    /**
     * Determines if the feed data is currently loading.
     */
    loading: boolean;
    /**
     * Indicates if the feed data was already loaded and is active.
     */
    loaded: boolean;
    /**
     * Stores the potential error when initializing or loading the feed.
     */
    error: any;
    /**
     * The currently stored feed data.
     */
    data: any;
  }

  /**
   * Custom errors defined outside of piral-core.
   */
  export interface PiralCustomErrors {
    tile: TileErrorInfoProps;
    menu: MenuItemErrorInfoProps;
    modal: ModalErrorInfoProps;
    feed: FeedErrorInfoProps;
  }

  /**
   * The error used when a registered extension component crashed.
   */
  export interface ExtensionErrorInfoProps {
    /**
     * The type of the error.
     */
    type: "extension";
    /**
     * The provided error details.
     */
    error: any;
  }

  /**
   * The error used when the app could not be loaded.
   */
  export interface LoadingErrorInfoProps {
    /**
     * The type of the error.
     */
    type: "loading";
    /**
     * The provided error details.
     */
    error: any;
  }

  /**
   * The error used when a registered page component crashes.
   */
  export interface PageErrorInfoProps extends ReactRouter.RouteComponentProps {
    /**
     * The type of the error.
     */
    type: "page";
    /**
     * The provided error details.
     */
    error: any;
  }

  /**
   * The error used when a route cannot be resolved.
   */
  export interface NotFoundErrorInfoProps extends ReactRouter.RouteComponentProps {
    /**
     * The type of the error.
     */
    type: "not_found";
  }

  /**
   * The error used when the exact type is unknown.
   */
  export interface UnknownErrorInfoProps {
    /**
     * The type of the error.
     */
    type: "unknown";
    /**
     * The provided error details.
     */
    error: any;
  }

  export interface LanguagesPickerProps {
    /**
     * The currently selected language.
     */
    selected: string;
    /**
     * The languages available for selection.
     */
    available: Array<string>;
  }

  export interface DashboardContainerProps extends ReactRouter.RouteComponentProps {}

  export interface DashboardTileProps {
    /**
     * The currently used number of columns.
     */
    columns: number;
    /**
     * The currently used number of rows.
     */
    rows: number;
    /**
     * The resizable status.
     */
    resizable: boolean;
    /**
     * The provided tile preferences.
     */
    meta: TilePreferences;
  }

  export interface MenuContainerProps {
    /**
     * The type of the menu.
     */
    type: MenuType;
  }

  export interface MenuItemProps {
    /**
     * The type of the menu.
     */
    type: MenuType;
    /**
     * The provided menu settings.
     */
    meta: MenuSettings;
  }

  export interface NotificationsHostProps {}

  export interface NotificationsToastProps extends BareNotificationProps {}

  export interface ModalsHostProps {
    /**
     * Gets if the modal is currently open or closed.
     */
    open: boolean;
    /**
     * Callback to invoke closing the modal dialog.
     */
    close(): void;
  }

  export interface ModalsDialogProps extends OpenModalDialog {}

  export type UnionOf<T> = {
    [K in keyof T]: T[K];
  }[keyof T];

  export interface TileRegistration extends BaseRegistration {
    component: WrappedComponent<TileComponentProps>;
    preferences: TilePreferences;
  }

  export interface MenuItemRegistration extends BaseRegistration {
    component: WrappedComponent<MenuComponentProps>;
    settings: MenuSettings;
  }

  export interface ModalRegistration extends BaseRegistration {
    name: string;
    component: WrappedComponent<ModalComponentProps<any>>;
    defaults: any;
  }

  /**
   * The base type for pilet component registration in the global state context.
   */
  export interface BaseRegistration {
    pilet: string;
  }

  export type WrappedComponent<TProps> = React.ComponentType<Without<TProps, keyof BaseComponentProps>>;

  export interface TileErrorInfoProps {
    /**
     * The type of the error.
     */
    type: "tile";
    /**
     * The provided error details.
     */
    error: any;
    /**
     * The currently used number of columns.
     */
    columns: number;
    /**
     * The currently used number of rows.
     */
    rows: number;
  }

  /**
   * The error used when a registered menu item component crashed.
   */
  export interface MenuItemErrorInfoProps {
    /**
     * The type of the error.
     */
    type: "menu";
    /**
     * The provided error details.
     */
    error: any;
    /**
     * The type of the used menu.
     */
    menu: MenuType;
  }

  /**
   * The error used when a registered modal dialog crashed.
   */
  export interface ModalErrorInfoProps {
    /**
     * The type of the error.
     */
    type: "modal";
    /**
     * The provided error details.
     */
    error: any;
    /**
     * Callback for closing the modal programmatically.
     */
    onClose(): void;
  }

  /**
   * The error used when loading a feed resulted in an error.
   */
  export interface FeedErrorInfoProps {
    /**
     * The type of the error.
     */
    type: "feed";
    /**
     * The provided error details.
     */
    error: any;
  }

  export type Without<T, K> = Pick<T, Exclude<keyof T, K>>;
}