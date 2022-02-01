Vue.component("toast", {
    props: ['show', 'message'],
    data: function () {
        return {



            snackbarColor: "",
            timeout: 3000,
            //messageProp: this.message,


        }
    },
    computed: {
        colorHex() {
            return this.show;
        },
        route: {
            get: function () {
                return this.show;
            },
            set: function (newValue) {
                this.show = newValue
            }
        }

    },




    template: `
        <div>
            <v-snackbar v-model="route"
                    :timeout="timeout"
                    :color="snackbarColor">
            {{ message }}

            <slot></slot>
        </v-snackbar>
<input :value="show" @input="$emit('update:show', $event.target.value)" />
        </div>
`


}
);